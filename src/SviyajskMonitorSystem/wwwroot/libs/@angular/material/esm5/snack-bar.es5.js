import * as tslib_1 from "tslib";
/**
 * @license
 * Copyright Google Inc. All Rights Reserved.
 *
 * Use of this source code is governed by an MIT-style license that can be
 * found in the LICENSE file at https://angular.io/license
 */
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, ElementRef, Inject, Injectable, InjectionToken, Injector, NgModule, NgZone, Optional, Renderer2, SkipSelf, ViewChild, ViewEncapsulation } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Overlay, OverlayConfig, OverlayModule } from '@angular/cdk/overlay';
import { BasePortalHost, ComponentPortal, PortalHostDirective, PortalModule } from '@angular/cdk/portal';
import { LIVE_ANNOUNCER_PROVIDER, LiveAnnouncer } from '@angular/cdk/a11y';
import { MdCommonModule, PortalInjector, extendObject } from '@angular/material/core';
import { Subject } from 'rxjs/Subject';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { first } from '@angular/cdk/rxjs';
var MD_SNACK_BAR_DATA = new InjectionToken('MdSnackBarData');
/**
 * Configuration used when opening a snack-bar.
 */
var MdSnackBarConfig = (function () {
    function MdSnackBarConfig() {
        /**
         * The politeness level for the MdAriaLiveAnnouncer announcement.
         */
        this.politeness = 'assertive';
        /**
         * Message to be announced by the MdAriaLiveAnnouncer
         */
        this.announcementMessage = '';
        /**
         * The length of time in milliseconds to wait before automatically dismissing the snack bar.
         */
        this.duration = 0;
        /**
         * Text layout direction for the snack bar.
         */
        this.direction = 'ltr';
        /**
         * Data being injected into the child component.
         */
        this.data = null;
        /**
         * The horizontal position to place the snack bar.
         */
        this.horizontalPosition = 'center';
        /**
         * The vertical position to place the snack bar.
         */
        this.verticalPosition = 'bottom';
    }
    return MdSnackBarConfig;
}());
/**
 * Reference to a snack bar dispatched from the snack bar service.
 */
var MdSnackBarRef = (function () {
    /**
     * @param {?} containerInstance
     * @param {?} _overlayRef
     */
    function MdSnackBarRef(containerInstance, _overlayRef) {
        var _this = this;
        this._overlayRef = _overlayRef;
        /**
         * Subject for notifying the user that the snack bar has closed.
         */
        this._afterClosed = new Subject();
        /**
         * Subject for notifying the user that the snack bar has opened and appeared.
         */
        this._afterOpened = new Subject();
        /**
         * Subject for notifying the user that the snack bar action was called.
         */
        this._onAction = new Subject();
        this.containerInstance = containerInstance;
        // Dismiss snackbar on action.
        this.onAction().subscribe(function () { return _this.dismiss(); });
        containerInstance._onExit.subscribe(function () { return _this._finishDismiss(); });
    }
    /**
     * Dismisses the snack bar.
     * @return {?}
     */
    MdSnackBarRef.prototype.dismiss = function () {
        if (!this._afterClosed.closed) {
            this.containerInstance.exit();
        }
        clearTimeout(this._durationTimeoutId);
    };
    /**
     * Marks the snackbar action clicked.
     * @return {?}
     */
    MdSnackBarRef.prototype.closeWithAction = function () {
        if (!this._onAction.closed) {
            this._onAction.next();
            this._onAction.complete();
        }
    };
    /**
     * Dismisses the snack bar after some duration
     * @param {?} duration
     * @return {?}
     */
    MdSnackBarRef.prototype._dismissAfter = function (duration) {
        var _this = this;
        this._durationTimeoutId = setTimeout(function () { return _this.dismiss(); }, duration);
    };
    /**
     * Marks the snackbar as opened
     * @return {?}
     */
    MdSnackBarRef.prototype._open = function () {
        if (!this._afterOpened.closed) {
            this._afterOpened.next();
            this._afterOpened.complete();
        }
    };
    /**
     * Cleans up the DOM after closing.
     * @return {?}
     */
    MdSnackBarRef.prototype._finishDismiss = function () {
        this._overlayRef.dispose();
        this._afterClosed.next();
        this._afterClosed.complete();
    };
    /**
     * Gets an observable that is notified when the snack bar is finished closing.
     * @return {?}
     */
    MdSnackBarRef.prototype.afterDismissed = function () {
        return this._afterClosed.asObservable();
    };
    /**
     * Gets an observable that is notified when the snack bar has opened and appeared.
     * @return {?}
     */
    MdSnackBarRef.prototype.afterOpened = function () {
        return this.containerInstance._onEnter;
    };
    /**
     * Gets an observable that is notified when the snack bar action is called.
     * @return {?}
     */
    MdSnackBarRef.prototype.onAction = function () {
        return this._onAction.asObservable();
    };
    return MdSnackBarRef;
}());
// TODO(jelbourn): we can't use constants from animation.ts here because you can't use
// a text interpolation in anything that is analyzed statically with ngc (for AoT compile).
var SHOW_ANIMATION = '225ms cubic-bezier(0.4,0.0,1,1)';
var HIDE_ANIMATION = '195ms cubic-bezier(0.0,0.0,0.2,1)';
/**
 * Internal component that wraps user-provided snack bar content.
 * \@docs-private
 */
var MdSnackBarContainer = (function (_super) {
    tslib_1.__extends(MdSnackBarContainer, _super);
    /**
     * @param {?} _ngZone
     * @param {?} _renderer
     * @param {?} _elementRef
     * @param {?} _changeDetectorRef
     */
    function MdSnackBarContainer(_ngZone, _renderer, _elementRef, _changeDetectorRef) {
        var _this = _super.call(this) || this;
        _this._ngZone = _ngZone;
        _this._renderer = _renderer;
        _this._elementRef = _elementRef;
        _this._changeDetectorRef = _changeDetectorRef;
        /**
         * Whether the component has been destroyed.
         */
        _this._destroyed = false;
        /**
         * Subject for notifying that the snack bar has exited from view.
         */
        _this._onExit = new Subject();
        /**
         * Subject for notifying that the snack bar has finished entering the view.
         */
        _this._onEnter = new Subject();
        return _this;
    }
    /**
     * Gets the current animation state both combining one of the possibilities from
     * SnackBarState and the vertical location.
     * @return {?}
     */
    MdSnackBarContainer.prototype.getAnimationState = function () {
        return this._animationState + "-" + this.snackBarConfig.verticalPosition;
    };
    /**
     * Attach a component portal as content to this snack bar container.
     * @template T
     * @param {?} portal
     * @return {?}
     */
    MdSnackBarContainer.prototype.attachComponentPortal = function (portal) {
        if (this._portalHost.hasAttached()) {
            throw Error('Attempting to attach snack bar content after content is already attached');
        }
        if (this.snackBarConfig.extraClasses) {
            // Not the most efficient way of adding classes, but the renderer doesn't allow us
            // to pass in an array or a space-separated list.
            for (var _i = 0, _a = this.snackBarConfig.extraClasses; _i < _a.length; _i++) {
                var cssClass = _a[_i];
                this._renderer.addClass(this._elementRef.nativeElement, cssClass);
            }
        }
        if (this.snackBarConfig.horizontalPosition === 'center') {
            this._renderer.addClass(this._elementRef.nativeElement, 'mat-snack-bar-center');
        }
        if (this.snackBarConfig.verticalPosition === 'top') {
            this._renderer.addClass(this._elementRef.nativeElement, 'mat-snack-bar-top');
        }
        return this._portalHost.attachComponentPortal(portal);
    };
    /**
     * Attach a template portal as content to this snack bar container.
     * @return {?}
     */
    MdSnackBarContainer.prototype.attachTemplatePortal = function () {
        throw Error('Not yet implemented');
    };
    /**
     * Handle end of animations, updating the state of the snackbar.
     * @param {?} event
     * @return {?}
     */
    MdSnackBarContainer.prototype.onAnimationEnd = function (event) {
        if (event.toState === 'void' || event.toState.startsWith('hidden')) {
            this._completeExit();
        }
        if (event.toState.startsWith('visible')) {
            // Note: we shouldn't use `this` inside the zone callback,
            // because it can cause a memory leak.
            var /** @type {?} */ onEnter_1 = this._onEnter;
            this._ngZone.run(function () {
                onEnter_1.next();
                onEnter_1.complete();
            });
        }
    };
    /**
     * Begin animation of snack bar entrance into view.
     * @return {?}
     */
    MdSnackBarContainer.prototype.enter = function () {
        if (!this._destroyed) {
            this._animationState = 'visible';
            this._changeDetectorRef.detectChanges();
        }
    };
    /**
     * Begin animation of the snack bar exiting from view.
     * @return {?}
     */
    MdSnackBarContainer.prototype.exit = function () {
        this._animationState = 'hidden';
        return this._onExit;
    };
    /**
     * Makes sure the exit callbacks have been invoked when the element is destroyed.
     * @return {?}
     */
    MdSnackBarContainer.prototype.ngOnDestroy = function () {
        this._destroyed = true;
        this._completeExit();
    };
    /**
     * Waits for the zone to settle before removing the element. Helps prevent
     * errors where we end up removing an element which is in the middle of an animation.
     * @return {?}
     */
    MdSnackBarContainer.prototype._completeExit = function () {
        var _this = this;
        first.call(this._ngZone.onMicrotaskEmpty.asObservable()).subscribe(function () {
            _this._onExit.next();
            _this._onExit.complete();
        });
    };
    return MdSnackBarContainer;
}(BasePortalHost));
MdSnackBarContainer.decorators = [
    { type: Component, args: [{ selector: 'snack-bar-container',
                template: "<ng-template cdkPortalHost></ng-template>",
                styles: [".mat-snack-bar-container{border-radius:2px;box-sizing:content-box;display:block;margin:24px;max-width:568px;min-width:288px;padding:14px 24px;transform:translateY(100%)}.mat-snack-bar-container.mat-snack-bar-center{margin:0}.mat-snack-bar-container.mat-snack-bar-top{transform:translateY(-100%)}@media screen and (-ms-high-contrast:active){.mat-snack-bar-container{border:solid 1px}}"],
                changeDetection: ChangeDetectionStrategy.OnPush,
                encapsulation: ViewEncapsulation.None,
                preserveWhitespaces: false,
                host: {
                    'role': 'alert',
                    'class': 'mat-snack-bar-container',
                    '[@state]': 'getAnimationState()',
                    '(@state.done)': 'onAnimationEnd($event)'
                },
                animations: [
                    trigger('state', [
                        // Animation from top.
                        state('visible-top', style({ transform: 'translateY(0%)' })),
                        state('hidden-top', style({ transform: 'translateY(-100%)' })),
                        transition('visible-top => hidden-top', animate(HIDE_ANIMATION)),
                        transition('void => visible-top', animate(SHOW_ANIMATION)),
                        // Animation from bottom.
                        state('visible-bottom', style({ transform: 'translateY(0%)' })),
                        state('hidden-bottom', style({ transform: 'translateY(100%)' })),
                        transition('visible-bottom => hidden-bottom', animate(HIDE_ANIMATION)),
                        transition('void => visible-bottom', animate(SHOW_ANIMATION)),
                    ])
                ],
            },] },
];
/**
 * @nocollapse
 */
MdSnackBarContainer.ctorParameters = function () { return [
    { type: NgZone, },
    { type: Renderer2, },
    { type: ElementRef, },
    { type: ChangeDetectorRef, },
]; };
MdSnackBarContainer.propDecorators = {
    '_portalHost': [{ type: ViewChild, args: [PortalHostDirective,] },],
};
/**
 * A component used to open as the default snack bar, matching material spec.
 * This should only be used internally by the snack bar service.
 */
var SimpleSnackBar = (function () {
    /**
     * @param {?} snackBarRef
     * @param {?} data
     */
    function SimpleSnackBar(snackBarRef, data) {
        this.snackBarRef = snackBarRef;
        this.data = data;
    }
    /**
     * Performs the action on the snack bar.
     * @return {?}
     */
    SimpleSnackBar.prototype.action = function () {
        this.snackBarRef.closeWithAction();
    };
    Object.defineProperty(SimpleSnackBar.prototype, "hasAction", {
        /**
         * If the action button should be shown.
         * @return {?}
         */
        get: function () {
            return !!this.data.action;
        },
        enumerable: true,
        configurable: true
    });
    return SimpleSnackBar;
}());
SimpleSnackBar.decorators = [
    { type: Component, args: [{ selector: 'simple-snack-bar',
                template: "{{data.message}} <button class=\"mat-simple-snackbar-action\" *ngIf=\"hasAction\" (click)=\"action()\">{{data.action}}</button>",
                styles: [".mat-simple-snackbar{display:flex;justify-content:space-between;line-height:20px}.mat-simple-snackbar-action{-webkit-user-select:none;-moz-user-select:none;-ms-user-select:none;user-select:none;cursor:pointer;outline:0;border:none;-webkit-tap-highlight-color:transparent;background:0 0;flex-shrink:0;margin-left:48px}[dir=rtl] .mat-simple-snackbar-action{margin-right:48px;margin-left:0}"],
                encapsulation: ViewEncapsulation.None,
                preserveWhitespaces: false,
                changeDetection: ChangeDetectionStrategy.OnPush,
                host: {
                    'class': 'mat-simple-snackbar',
                }
            },] },
];
/**
 * @nocollapse
 */
SimpleSnackBar.ctorParameters = function () { return [
    { type: MdSnackBarRef, },
    { type: undefined, decorators: [{ type: Inject, args: [MD_SNACK_BAR_DATA,] },] },
]; };
/**
 * Service to dispatch Material Design snack bar messages.
 */
var MdSnackBar = (function () {
    /**
     * @param {?} _overlay
     * @param {?} _live
     * @param {?} _injector
     * @param {?} _parentSnackBar
     */
    function MdSnackBar(_overlay, _live, _injector, _parentSnackBar) {
        this._overlay = _overlay;
        this._live = _live;
        this._injector = _injector;
        this._parentSnackBar = _parentSnackBar;
        /**
         * Reference to the current snack bar in the view *at this level* (in the Angular injector tree).
         * If there is a parent snack-bar service, all operations should delegate to that parent
         * via `_openedSnackBarRef`.
         */
        this._snackBarRefAtThisLevel = null;
    }
    Object.defineProperty(MdSnackBar.prototype, "_openedSnackBarRef", {
        /**
         * Reference to the currently opened snackbar at *any* level.
         * @return {?}
         */
        get: function () {
            var /** @type {?} */ parent = this._parentSnackBar;
            return parent ? parent._openedSnackBarRef : this._snackBarRefAtThisLevel;
        },
        /**
         * @param {?} value
         * @return {?}
         */
        set: function (value) {
            if (this._parentSnackBar) {
                this._parentSnackBar._openedSnackBarRef = value;
            }
            else {
                this._snackBarRefAtThisLevel = value;
            }
        },
        enumerable: true,
        configurable: true
    });
    /**
     * Creates and dispatches a snack bar with a custom component for the content, removing any
     * currently opened snack bars.
     *
     * @template T
     * @param {?} component Component to be instantiated.
     * @param {?=} config Extra configuration for the snack bar.
     * @return {?}
     */
    MdSnackBar.prototype.openFromComponent = function (component, config) {
        var _this = this;
        var /** @type {?} */ _config = _applyConfigDefaults(config);
        var /** @type {?} */ snackBarRef = this._attach(component, _config);
        // When the snackbar is dismissed, clear the reference to it.
        snackBarRef.afterDismissed().subscribe(function () {
            // Clear the snackbar ref if it hasn't already been replaced by a newer snackbar.
            if (_this._openedSnackBarRef == snackBarRef) {
                _this._openedSnackBarRef = null;
            }
        });
        if (this._openedSnackBarRef) {
            // If a snack bar is already in view, dismiss it and enter the
            // new snack bar after exit animation is complete.
            this._openedSnackBarRef.afterDismissed().subscribe(function () {
                snackBarRef.containerInstance.enter();
            });
            this._openedSnackBarRef.dismiss();
        }
        else {
            // If no snack bar is in view, enter the new snack bar.
            snackBarRef.containerInstance.enter();
        }
        // If a dismiss timeout is provided, set up dismiss based on after the snackbar is opened.
        if (_config.duration && _config.duration > 0) {
            snackBarRef.afterOpened().subscribe(function () { return snackBarRef._dismissAfter(/** @type {?} */ ((((_config)).duration))); });
        }
        if (_config.announcementMessage) {
            this._live.announce(_config.announcementMessage, _config.politeness);
        }
        this._openedSnackBarRef = snackBarRef;
        return this._openedSnackBarRef;
    };
    /**
     * Opens a snackbar with a message and an optional action.
     * @param {?} message The message to show in the snackbar.
     * @param {?=} action The label for the snackbar action.
     * @param {?=} config Additional configuration options for the snackbar.
     * @return {?}
     */
    MdSnackBar.prototype.open = function (message, action, config) {
        if (action === void 0) { action = ''; }
        var /** @type {?} */ _config = _applyConfigDefaults(config);
        // Since the user doesn't have access to the component, we can
        // override the data to pass in our own message and action.
        _config.data = { message: message, action: action };
        _config.announcementMessage = message;
        return this.openFromComponent(SimpleSnackBar, _config);
    };
    /**
     * Dismisses the currently-visible snack bar.
     * @return {?}
     */
    MdSnackBar.prototype.dismiss = function () {
        if (this._openedSnackBarRef) {
            this._openedSnackBarRef.dismiss();
        }
    };
    /**
     * Attaches the snack bar container component to the overlay.
     * @param {?} overlayRef
     * @param {?} config
     * @return {?}
     */
    MdSnackBar.prototype._attachSnackBarContainer = function (overlayRef, config) {
        var /** @type {?} */ containerPortal = new ComponentPortal(MdSnackBarContainer, config.viewContainerRef);
        var /** @type {?} */ containerRef = overlayRef.attach(containerPortal);
        containerRef.instance.snackBarConfig = config;
        return containerRef.instance;
    };
    /**
     * Places a new component as the content of the snack bar container.
     * @template T
     * @param {?} component
     * @param {?} config
     * @return {?}
     */
    MdSnackBar.prototype._attach = function (component, config) {
        var /** @type {?} */ overlayRef = this._createOverlay(config);
        var /** @type {?} */ container = this._attachSnackBarContainer(overlayRef, config);
        var /** @type {?} */ snackBarRef = new MdSnackBarRef(container, overlayRef);
        var /** @type {?} */ injector = this._createInjector(config, snackBarRef);
        var /** @type {?} */ portal = new ComponentPortal(component, undefined, injector);
        var /** @type {?} */ contentRef = container.attachComponentPortal(portal);
        // We can't pass this via the injector, because the injector is created earlier.
        snackBarRef.instance = contentRef.instance;
        return snackBarRef;
    };
    /**
     * Creates a new overlay and places it in the correct location.
     * @param {?} config The user-specified snack bar config.
     * @return {?}
     */
    MdSnackBar.prototype._createOverlay = function (config) {
        var /** @type {?} */ state$$1 = new OverlayConfig();
        state$$1.direction = config.direction;
        var /** @type {?} */ positionStrategy = this._overlay.position().global();
        // Set horizontal position.
        var /** @type {?} */ isRtl = config.direction === 'rtl';
        var /** @type {?} */ isLeft = (config.horizontalPosition === 'left' ||
            (config.horizontalPosition === 'start' && !isRtl) ||
            (config.horizontalPosition === 'end' && isRtl));
        var /** @type {?} */ isRight = !isLeft && config.horizontalPosition !== 'center';
        if (isLeft) {
            positionStrategy.left('0');
        }
        else if (isRight) {
            positionStrategy.right('0');
        }
        else {
            positionStrategy.centerHorizontally();
        }
        // Set horizontal position.
        if (config.verticalPosition === 'top') {
            positionStrategy.top('0');
        }
        else {
            positionStrategy.bottom('0');
        }
        state$$1.positionStrategy = positionStrategy;
        return this._overlay.create(state$$1);
    };
    /**
     * Creates an injector to be used inside of a snack bar component.
     * @template T
     * @param {?} config Config that was used to create the snack bar.
     * @param {?} snackBarRef Reference to the snack bar.
     * @return {?}
     */
    MdSnackBar.prototype._createInjector = function (config, snackBarRef) {
        var /** @type {?} */ userInjector = config && config.viewContainerRef && config.viewContainerRef.injector;
        var /** @type {?} */ injectionTokens = new WeakMap();
        injectionTokens.set(MdSnackBarRef, snackBarRef);
        injectionTokens.set(MD_SNACK_BAR_DATA, config.data);
        return new PortalInjector(userInjector || this._injector, injectionTokens);
    };
    return MdSnackBar;
}());
MdSnackBar.decorators = [
    { type: Injectable },
];
/**
 * @nocollapse
 */
MdSnackBar.ctorParameters = function () { return [
    { type: Overlay, },
    { type: LiveAnnouncer, },
    { type: Injector, },
    { type: MdSnackBar, decorators: [{ type: Optional }, { type: SkipSelf },] },
]; };
/**
 * Applies default options to the snackbar config.
 * @param {?=} config The configuration to which the defaults will be applied.
 * @return {?} The new configuration object with defaults applied.
 */
function _applyConfigDefaults(config) {
    return extendObject(new MdSnackBarConfig(), config);
}
var MdSnackBarModule = (function () {
    function MdSnackBarModule() {
    }
    return MdSnackBarModule;
}());
MdSnackBarModule.decorators = [
    { type: NgModule, args: [{
                imports: [
                    OverlayModule,
                    PortalModule,
                    CommonModule,
                    MdCommonModule,
                ],
                exports: [MdSnackBarContainer, MdCommonModule],
                declarations: [MdSnackBarContainer, SimpleSnackBar],
                entryComponents: [MdSnackBarContainer, SimpleSnackBar],
                providers: [MdSnackBar, LIVE_ANNOUNCER_PROVIDER]
            },] },
];
/**
 * @nocollapse
 */
MdSnackBarModule.ctorParameters = function () { return []; };
/**
 * Generated bundle index. Do not edit.
 */
export { MdSnackBarModule, MdSnackBar, SHOW_ANIMATION, HIDE_ANIMATION, MdSnackBarContainer, MD_SNACK_BAR_DATA, MdSnackBarConfig, MdSnackBarRef, SimpleSnackBar, MD_SNACK_BAR_DATA as MAT_SNACK_BAR_DATA, MdSnackBar as MatSnackBar, MdSnackBarConfig as MatSnackBarConfig, MdSnackBarContainer as MatSnackBarContainer, MdSnackBarModule as MatSnackBarModule, MdSnackBarRef as MatSnackBarRef };
//# sourceMappingURL=snack-bar.es5.js.map
