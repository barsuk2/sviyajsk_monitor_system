import * as tslib_1 from "tslib";
/**
 * @license
 * Copyright Google Inc. All Rights Reserved.
 *
 * Use of this source code is governed by an MIT-style license that can be
 * found in the LICENSE file at https://angular.io/license
 */
import { ObserversModule } from '@angular/cdk/observers';
import { PortalHostDirective, PortalModule, TemplatePortalDirective } from '@angular/cdk/portal';
import { ScrollDispatchModule, VIEWPORT_RULER_PROVIDER, ViewportRuler } from '@angular/cdk/scrolling';
import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, ContentChild, ContentChildren, Directive, ElementRef, EventEmitter, Inject, Input, NgModule, NgZone, Optional, Output, Renderer2, TemplateRef, ViewChild, ViewContainerRef, ViewEncapsulation, forwardRef } from '@angular/core';
import { MATERIAL_COMPATIBILITY_MODE, MD_RIPPLE_GLOBAL_OPTIONS, MdCommonModule, MdRipple, MdRippleModule, TemplatePortal, mixinColor, mixinDisableRipple, mixinDisabled } from '@angular/material/core';
import { Subject } from 'rxjs/Subject';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { Directionality } from '@angular/cdk/bidi';
import { coerceBooleanProperty } from '@angular/cdk/coercion';
import { Subscription } from 'rxjs/Subscription';
import { merge } from 'rxjs/observable/merge';
import { ENTER, LEFT_ARROW, RIGHT_ARROW, SPACE } from '@angular/cdk/keycodes';
import { auditTime, startWith, takeUntil } from '@angular/cdk/rxjs';
import { fromEvent } from 'rxjs/observable/fromEvent';
import { of } from 'rxjs/observable/of';
import { Platform } from '@angular/cdk/platform';
/**
 * The ink-bar is used to display and animate the line underneath the current active tab label.
 * \@docs-private
 */
var MdInkBar = (function () {
    /**
     * @param {?} _renderer
     * @param {?} _elementRef
     * @param {?} _ngZone
     */
    function MdInkBar(_renderer, _elementRef, _ngZone) {
        this._renderer = _renderer;
        this._elementRef = _elementRef;
        this._ngZone = _ngZone;
    }
    /**
     * Calculates the styles from the provided element in order to align the ink-bar to that element.
     * Shows the ink bar if previously set as hidden.
     * @param {?} element
     * @return {?}
     */
    MdInkBar.prototype.alignToElement = function (element) {
        var _this = this;
        this.show();
        if (typeof requestAnimationFrame !== 'undefined') {
            this._ngZone.runOutsideAngular(function () {
                requestAnimationFrame(function () { return _this._setStyles(element); });
            });
        }
        else {
            this._setStyles(element);
        }
    };
    /**
     * Shows the ink bar.
     * @return {?}
     */
    MdInkBar.prototype.show = function () {
        this._renderer.setStyle(this._elementRef.nativeElement, 'visibility', 'visible');
    };
    /**
     * Hides the ink bar.
     * @return {?}
     */
    MdInkBar.prototype.hide = function () {
        this._renderer.setStyle(this._elementRef.nativeElement, 'visibility', 'hidden');
    };
    /**
     * Sets the proper styles to the ink bar element.
     * @param {?} element
     * @return {?}
     */
    MdInkBar.prototype._setStyles = function (element) {
        var /** @type {?} */ left = element ? (element.offsetLeft || 0) + 'px' : '0';
        var /** @type {?} */ width = element ? (element.offsetWidth || 0) + 'px' : '0';
        this._renderer.setStyle(this._elementRef.nativeElement, 'left', left);
        this._renderer.setStyle(this._elementRef.nativeElement, 'width', width);
    };
    return MdInkBar;
}());
MdInkBar.decorators = [
    { type: Directive, args: [{
                selector: 'md-ink-bar, mat-ink-bar',
                host: {
                    'class': 'mat-ink-bar',
                },
            },] },
];
/**
 * @nocollapse
 */
MdInkBar.ctorParameters = function () { return [
    { type: Renderer2, },
    { type: ElementRef, },
    { type: NgZone, },
]; };
/**
 * Workaround for https://github.com/angular/angular/issues/17849
 */
var _MdTabLabelBaseClass = TemplatePortalDirective;
/**
 * Used to flag tab labels for use with the portal directive
 */
var MdTabLabel = (function (_super) {
    tslib_1.__extends(MdTabLabel, _super);
    /**
     * @param {?} templateRef
     * @param {?} viewContainerRef
     */
    function MdTabLabel(templateRef, viewContainerRef) {
        return _super.call(this, templateRef, viewContainerRef) || this;
    }
    return MdTabLabel;
}(_MdTabLabelBaseClass));
MdTabLabel.decorators = [
    { type: Directive, args: [{
                selector: '[md-tab-label], [mat-tab-label], [mdTabLabel], [matTabLabel]',
            },] },
];
/**
 * @nocollapse
 */
MdTabLabel.ctorParameters = function () { return [
    { type: TemplateRef, },
    { type: ViewContainerRef, },
]; };
/**
 * \@docs-private
 */
var MdTabBase = (function () {
    function MdTabBase() {
    }
    return MdTabBase;
}());
var _MdTabMixinBase = mixinDisabled(MdTabBase);
var MdTab = (function (_super) {
    tslib_1.__extends(MdTab, _super);
    /**
     * @param {?} _viewContainerRef
     */
    function MdTab(_viewContainerRef) {
        var _this = _super.call(this) || this;
        _this._viewContainerRef = _viewContainerRef;
        /**
         * The plain text label for the tab, used when there is no template label.
         */
        _this.textLabel = '';
        /**
         * The portal that will be the hosted content of the tab
         */
        _this._contentPortal = null;
        /**
         * Emits whenever the label changes.
         */
        _this._labelChange = new Subject();
        /**
         * Emits whenevfer the disable changes
         */
        _this._disableChange = new Subject();
        /**
         * The relatively indexed position where 0 represents the center, negative is left, and positive
         * represents the right.
         */
        _this.position = null;
        /**
         * The initial relatively index origin of the tab if it was created and selected after there
         * was already a selected tab. Provides context of what position the tab should originate from.
         */
        _this.origin = null;
        /**
         * Whether the tab is currently active.
         */
        _this.isActive = false;
        return _this;
    }
    Object.defineProperty(MdTab.prototype, "content", {
        /**
         * @return {?}
         */
        get: function () { return this._contentPortal; },
        enumerable: true,
        configurable: true
    });
    /**
     * @param {?} changes
     * @return {?}
     */
    MdTab.prototype.ngOnChanges = function (changes) {
        if (changes.hasOwnProperty('textLabel')) {
            this._labelChange.next();
        }
        if (changes.hasOwnProperty('disabled')) {
            this._disableChange.next();
        }
    };
    /**
     * @return {?}
     */
    MdTab.prototype.ngOnDestroy = function () {
        this._disableChange.complete();
        this._labelChange.complete();
    };
    /**
     * @return {?}
     */
    MdTab.prototype.ngOnInit = function () {
        this._contentPortal = new TemplatePortal(this._content, this._viewContainerRef);
    };
    return MdTab;
}(_MdTabMixinBase));
MdTab.decorators = [
    { type: Component, args: [{ selector: 'md-tab, mat-tab',
                template: "<ng-template><ng-content></ng-content></ng-template>",
                inputs: ['disabled'],
                changeDetection: ChangeDetectionStrategy.OnPush,
                encapsulation: ViewEncapsulation.None,
                preserveWhitespaces: false,
                exportAs: 'mdTab, matTab',
            },] },
];
/**
 * @nocollapse
 */
MdTab.ctorParameters = function () { return [
    { type: ViewContainerRef, },
]; };
MdTab.propDecorators = {
    'templateLabel': [{ type: ContentChild, args: [MdTabLabel,] },],
    '_content': [{ type: ViewChild, args: [TemplateRef,] },],
    'textLabel': [{ type: Input, args: ['label',] },],
};
/**
 * Wrapper for the contents of a tab.
 * \@docs-private
 */
var MdTabBody = (function () {
    /**
     * @param {?} _elementRef
     * @param {?} _dir
     */
    function MdTabBody(_elementRef, _dir) {
        this._elementRef = _elementRef;
        this._dir = _dir;
        /**
         * Event emitted when the tab begins to animate towards the center as the active tab.
         */
        this.onCentering = new EventEmitter();
        /**
         * Event emitted when the tab completes its animation towards the center.
         */
        this.onCentered = new EventEmitter(true);
    }
    Object.defineProperty(MdTabBody.prototype, "position", {
        /**
         * @param {?} position
         * @return {?}
         */
        set: function (position) {
            if (position < 0) {
                this._position = this._getLayoutDirection() == 'ltr' ? 'left' : 'right';
            }
            else if (position > 0) {
                this._position = this._getLayoutDirection() == 'ltr' ? 'right' : 'left';
            }
            else {
                this._position = 'center';
            }
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdTabBody.prototype, "origin", {
        /**
         * The origin position from which this tab should appear when it is centered into view.
         * @param {?} origin
         * @return {?}
         */
        set: function (origin) {
            if (origin == null) {
                return;
            }
            var /** @type {?} */ dir = this._getLayoutDirection();
            if ((dir == 'ltr' && origin <= 0) || (dir == 'rtl' && origin > 0)) {
                this._origin = 'left';
            }
            else {
                this._origin = 'right';
            }
        },
        enumerable: true,
        configurable: true
    });
    /**
     * After initialized, check if the content is centered and has an origin. If so, set the
     * special position states that transition the tab from the left or right before centering.
     * @return {?}
     */
    MdTabBody.prototype.ngOnInit = function () {
        if (this._position == 'center' && this._origin) {
            this._position = this._origin == 'left' ? 'left-origin-center' : 'right-origin-center';
        }
    };
    /**
     * After the view has been set, check if the tab content is set to the center and attach the
     * content if it is not already attached.
     * @return {?}
     */
    MdTabBody.prototype.ngAfterViewChecked = function () {
        if (this._isCenterPosition(this._position) && !this._portalHost.hasAttached()) {
            this._portalHost.attach(this._content);
        }
    };
    /**
     * @param {?} e
     * @return {?}
     */
    MdTabBody.prototype._onTranslateTabStarted = function (e) {
        if (this._isCenterPosition(e.toState)) {
            this.onCentering.emit(this._elementRef.nativeElement.clientHeight);
        }
    };
    /**
     * @param {?} e
     * @return {?}
     */
    MdTabBody.prototype._onTranslateTabComplete = function (e) {
        // If the end state is that the tab is not centered, then detach the content.
        if (!this._isCenterPosition(e.toState) && !this._isCenterPosition(this._position)) {
            this._portalHost.detach();
        }
        // If the transition to the center is complete, emit an event.
        if (this._isCenterPosition(e.toState) && this._isCenterPosition(this._position)) {
            this.onCentered.emit();
        }
    };
    /**
     * The text direction of the containing app.
     * @return {?}
     */
    MdTabBody.prototype._getLayoutDirection = function () {
        return this._dir && this._dir.value === 'rtl' ? 'rtl' : 'ltr';
    };
    /**
     * Whether the provided position state is considered center, regardless of origin.
     * @param {?} position
     * @return {?}
     */
    MdTabBody.prototype._isCenterPosition = function (position) {
        return position == 'center' ||
            position == 'left-origin-center' ||
            position == 'right-origin-center';
    };
    return MdTabBody;
}());
MdTabBody.decorators = [
    { type: Component, args: [{ selector: 'md-tab-body, mat-tab-body',
                template: "<div class=\"mat-tab-body-content\" #content [@translateTab]=\"_position\" (@translateTab.start)=\"_onTranslateTabStarted($event)\" (@translateTab.done)=\"_onTranslateTabComplete($event)\"><ng-template cdkPortalHost></ng-template></div>",
                styles: [".mat-tab-body-content{height:100%;overflow:auto}.mat-tab-group-dynamic-height .mat-tab-body-content{overflow:hidden}"],
                encapsulation: ViewEncapsulation.None,
                preserveWhitespaces: false,
                changeDetection: ChangeDetectionStrategy.OnPush,
                host: {
                    'class': 'mat-tab-body',
                },
                animations: [
                    trigger('translateTab', [
                        state('void', style({ transform: 'translate3d(0%, 0, 0)' })),
                        state('left', style({ transform: 'translate3d(-100%, 0, 0)' })),
                        state('left-origin-center', style({ transform: 'translate3d(0%, 0, 0)' })),
                        state('right-origin-center', style({ transform: 'translate3d(0%, 0, 0)' })),
                        state('center', style({ transform: 'translate3d(0%, 0, 0)' })),
                        state('right', style({ transform: 'translate3d(100%, 0, 0)' })),
                        transition('* => left, * => right, left => center, right => center', animate('500ms cubic-bezier(0.35, 0, 0.25, 1)')),
                        transition('void => left-origin-center', [
                            style({ transform: 'translate3d(-100%, 0, 0)' }),
                            animate('500ms cubic-bezier(0.35, 0, 0.25, 1)')
                        ]),
                        transition('void => right-origin-center', [
                            style({ transform: 'translate3d(100%, 0, 0)' }),
                            animate('500ms cubic-bezier(0.35, 0, 0.25, 1)')
                        ])
                    ])
                ]
            },] },
];
/**
 * @nocollapse
 */
MdTabBody.ctorParameters = function () { return [
    { type: ElementRef, },
    { type: Directionality, decorators: [{ type: Optional },] },
]; };
MdTabBody.propDecorators = {
    '_portalHost': [{ type: ViewChild, args: [PortalHostDirective,] },],
    'onCentering': [{ type: Output },],
    'onCentered': [{ type: Output },],
    '_content': [{ type: Input, args: ['content',] },],
    'position': [{ type: Input, args: ['position',] },],
    'origin': [{ type: Input, args: ['origin',] },],
};
/**
 * Used to generate unique ID's for each tab component
 */
var nextId = 0;
/**
 * A simple change event emitted on focus or selection changes.
 */
var MdTabChangeEvent = (function () {
    function MdTabChangeEvent() {
    }
    return MdTabChangeEvent;
}());
/**
 * \@docs-private
 */
var MdTabGroupBase = (function () {
    /**
     * @param {?} _renderer
     * @param {?} _elementRef
     */
    function MdTabGroupBase(_renderer, _elementRef) {
        this._renderer = _renderer;
        this._elementRef = _elementRef;
    }
    return MdTabGroupBase;
}());
var _MdTabGroupMixinBase = mixinColor(mixinDisableRipple(MdTabGroupBase), 'primary');
/**
 * Material design tab-group component.  Supports basic tab pairs (label + content) and includes
 * animated ink-bar, keyboard navigation, and screen reader.
 * See: https://www.google.com/design/spec/components/tabs.html
 */
var MdTabGroup = (function (_super) {
    tslib_1.__extends(MdTabGroup, _super);
    /**
     * @param {?} _renderer
     * @param {?} elementRef
     * @param {?} _changeDetectorRef
     */
    function MdTabGroup(_renderer, elementRef, _changeDetectorRef) {
        var _this = _super.call(this, _renderer, elementRef) || this;
        _this._changeDetectorRef = _changeDetectorRef;
        /**
         * Whether this component has been initialized.
         */
        _this._isInitialized = false;
        /**
         * The tab index that should be selected after the content has been checked.
         */
        _this._indexToSelect = 0;
        /**
         * Snapshot of the height of the tab body wrapper before another tab is activated.
         */
        _this._tabBodyWrapperHeight = 0;
        /**
         * Subscription to tabs being added/removed.
         */
        _this._tabsSubscription = Subscription.EMPTY;
        /**
         * Subscription to changes in the tab labels.
         */
        _this._tabLabelSubscription = Subscription.EMPTY;
        _this._dynamicHeight = false;
        _this._selectedIndex = null;
        /**
         * Position of the tab header.
         */
        _this.headerPosition = 'above';
        /**
         * Output to enable support for two-way binding on `[(selectedIndex)]`
         */
        _this.selectedIndexChange = new EventEmitter();
        /**
         * Event emitted when focus has changed within a tab group.
         */
        _this.focusChange = new EventEmitter();
        /**
         * Event emitted when the tab selection has changed.
         */
        _this.selectChange = new EventEmitter(true);
        _this._groupId = nextId++;
        return _this;
    }
    Object.defineProperty(MdTabGroup.prototype, "dynamicHeight", {
        /**
         * Whether the tab group should grow to the size of the active tab.
         * @return {?}
         */
        get: function () { return this._dynamicHeight; },
        /**
         * @param {?} value
         * @return {?}
         */
        set: function (value) { this._dynamicHeight = coerceBooleanProperty(value); },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdTabGroup.prototype, "_dynamicHeightDeprecated", {
        /**
         * @deprecated
         * @return {?}
         */
        get: function () { return this._dynamicHeight; },
        /**
         * @param {?} value
         * @return {?}
         */
        set: function (value) { this._dynamicHeight = value; },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdTabGroup.prototype, "selectedIndex", {
        /**
         * @return {?}
         */
        get: function () { return this._selectedIndex; },
        /**
         * The index of the active tab.
         * @param {?} value
         * @return {?}
         */
        set: function (value) { this._indexToSelect = value; },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdTabGroup.prototype, "backgroundColor", {
        /**
         * Background color of the tab group.
         * @return {?}
         */
        get: function () { return this._backgroundColor; },
        /**
         * @param {?} value
         * @return {?}
         */
        set: function (value) {
            var /** @type {?} */ nativeElement = this._elementRef.nativeElement;
            this._renderer.removeClass(nativeElement, "mat-background-" + this.backgroundColor);
            if (value) {
                this._renderer.addClass(nativeElement, "mat-background-" + value);
            }
            this._backgroundColor = value;
        },
        enumerable: true,
        configurable: true
    });
    /**
     * After the content is checked, this component knows what tabs have been defined
     * and what the selected index should be. This is where we can know exactly what position
     * each tab should be in according to the new selected index, and additionally we know how
     * a new selected tab should transition in (from the left or right).
     * @return {?}
     */
    MdTabGroup.prototype.ngAfterContentChecked = function () {
        var _this = this;
        // Clamp the next selected index to the boundsof 0 and the tabs length.
        // Note the `|| 0`, which ensures that values like NaN can't get through
        // and which would otherwise throw the component into an infinite loop
        // (since Math.max(NaN, 0) === NaN).
        var /** @type {?} */ indexToSelect = this._indexToSelect =
            Math.min(this._tabs.length - 1, Math.max(this._indexToSelect || 0, 0));
        // If there is a change in selected index, emit a change event. Should not trigger if
        // the selected index has not yet been initialized.
        if (this._selectedIndex != indexToSelect && this._selectedIndex != null) {
            this.selectChange.emit(this._createChangeEvent(indexToSelect));
            // Emitting this value after change detection has run
            // since the checked content may contain this variable'
            Promise.resolve().then(function () { return _this.selectedIndexChange.emit(indexToSelect); });
        }
        // Setup the position for each tab and optionally setup an origin on the next selected tab.
        this._tabs.forEach(function (tab, index) {
            tab.position = index - indexToSelect;
            tab.isActive = index === indexToSelect;
            // If there is already a selected tab, then set up an origin for the next selected tab
            // if it doesn't have one already.
            if (_this._selectedIndex != null && tab.position == 0 && !tab.origin) {
                tab.origin = indexToSelect - _this._selectedIndex;
            }
        });
        if (this._selectedIndex !== indexToSelect) {
            this._selectedIndex = indexToSelect;
            this._changeDetectorRef.markForCheck();
        }
    };
    /**
     * @return {?}
     */
    MdTabGroup.prototype.ngAfterContentInit = function () {
        var _this = this;
        this._subscribeToTabLabels();
        // Subscribe to changes in the amount of tabs, in order to be
        // able to re-render the content as new tabs are added or removed.
        this._tabsSubscription = this._tabs.changes.subscribe(function () {
            _this._subscribeToTabLabels();
            _this._changeDetectorRef.markForCheck();
        });
    };
    /**
     * @return {?}
     */
    MdTabGroup.prototype.ngOnDestroy = function () {
        this._tabsSubscription.unsubscribe();
        this._tabLabelSubscription.unsubscribe();
    };
    /**
     * Waits one frame for the view to update, then updates the ink bar
     * Note: This must be run outside of the zone or it will create an infinite change detection loop.
     * @return {?}
     */
    MdTabGroup.prototype.ngAfterViewChecked = function () {
        this._isInitialized = true;
    };
    /**
     * @param {?} index
     * @return {?}
     */
    MdTabGroup.prototype._focusChanged = function (index) {
        this.focusChange.emit(this._createChangeEvent(index));
    };
    /**
     * @param {?} index
     * @return {?}
     */
    MdTabGroup.prototype._createChangeEvent = function (index) {
        var /** @type {?} */ event = new MdTabChangeEvent;
        event.index = index;
        if (this._tabs && this._tabs.length) {
            event.tab = this._tabs.toArray()[index];
        }
        return event;
    };
    /**
     * Subscribes to changes in the tab labels. This is needed, because the \@Input for the label is
     * on the MdTab component, whereas the data binding is inside the MdTabGroup. In order for the
     * binding to be updated, we need to subscribe to changes in it and trigger change detection
     * manually.
     * @return {?}
     */
    MdTabGroup.prototype._subscribeToTabLabels = function () {
        var _this = this;
        if (this._tabLabelSubscription) {
            this._tabLabelSubscription.unsubscribe();
        }
        this._tabLabelSubscription = merge.apply(void 0, this._tabs.map(function (tab) { return tab._disableChange; }).concat(this._tabs.map(function (tab) { return tab._labelChange; }))).subscribe(function () {
            _this._changeDetectorRef.markForCheck();
        });
    };
    /**
     * Returns a unique id for each tab label element
     * @param {?} i
     * @return {?}
     */
    MdTabGroup.prototype._getTabLabelId = function (i) {
        return "md-tab-label-" + this._groupId + "-" + i;
    };
    /**
     * Returns a unique id for each tab content element
     * @param {?} i
     * @return {?}
     */
    MdTabGroup.prototype._getTabContentId = function (i) {
        return "md-tab-content-" + this._groupId + "-" + i;
    };
    /**
     * Sets the height of the body wrapper to the height of the activating tab if dynamic
     * height property is true.
     * @param {?} tabHeight
     * @return {?}
     */
    MdTabGroup.prototype._setTabBodyWrapperHeight = function (tabHeight) {
        if (!this._dynamicHeight || !this._tabBodyWrapperHeight) {
            return;
        }
        this._renderer.setStyle(this._tabBodyWrapper.nativeElement, 'height', this._tabBodyWrapperHeight + 'px');
        // This conditional forces the browser to paint the height so that
        // the animation to the new height can have an origin.
        if (this._tabBodyWrapper.nativeElement.offsetHeight) {
            this._renderer.setStyle(this._tabBodyWrapper.nativeElement, 'height', tabHeight + 'px');
        }
    };
    /**
     * Removes the height of the tab body wrapper.
     * @return {?}
     */
    MdTabGroup.prototype._removeTabBodyWrapperHeight = function () {
        this._tabBodyWrapperHeight = this._tabBodyWrapper.nativeElement.clientHeight;
        this._renderer.setStyle(this._tabBodyWrapper.nativeElement, 'height', '');
    };
    return MdTabGroup;
}(_MdTabGroupMixinBase));
MdTabGroup.decorators = [
    { type: Component, args: [{ selector: 'md-tab-group, mat-tab-group',
                template: "<mat-tab-header #tabHeader [selectedIndex]=\"selectedIndex\" [disableRipple]=\"disableRipple\" (indexFocused)=\"_focusChanged($event)\" (selectFocusedIndex)=\"selectedIndex = $event\"><div class=\"mat-tab-label\" role=\"tab\" matTabLabelWrapper mat-ripple *ngFor=\"let tab of _tabs; let i = index\" [id]=\"_getTabLabelId(i)\" [tabIndex]=\"selectedIndex == i ? 0 : -1\" [attr.aria-controls]=\"_getTabContentId(i)\" [attr.aria-selected]=\"selectedIndex == i\" [class.mat-tab-label-active]=\"selectedIndex == i\" [disabled]=\"tab.disabled\" [matRippleDisabled]=\"disableRipple\" (click)=\"tabHeader.focusIndex = selectedIndex = i\"><ng-template [ngIf]=\"tab.templateLabel\"><ng-template [cdkPortalHost]=\"tab.templateLabel\"></ng-template></ng-template><ng-template [ngIf]=\"!tab.templateLabel\">{{tab.textLabel}}</ng-template></div></mat-tab-header><div class=\"mat-tab-body-wrapper\" #tabBodyWrapper><mat-tab-body role=\"tabpanel\" *ngFor=\"let tab of _tabs; let i = index\" [id]=\"_getTabContentId(i)\" [attr.aria-labelledby]=\"_getTabLabelId(i)\" [class.mat-tab-body-active]=\"selectedIndex == i\" [content]=\"tab.content\" [position]=\"tab.position\" [origin]=\"tab.origin\" (onCentered)=\"_removeTabBodyWrapperHeight()\" (onCentering)=\"_setTabBodyWrapperHeight($event)\"></mat-tab-body></div>",
                styles: [".mat-tab-group{display:flex;flex-direction:column}.mat-tab-group.mat-tab-group-inverted-header{flex-direction:column-reverse}.mat-tab-label{height:48px;padding:0 24px;cursor:pointer;box-sizing:border-box;opacity:.6;min-width:160px;text-align:center;display:inline-flex;justify-content:center;align-items:center;white-space:nowrap;position:relative}.mat-tab-label:focus{outline:0;opacity:1}.mat-tab-label.mat-tab-disabled{cursor:default;pointer-events:none}@media (max-width:600px){.mat-tab-label{padding:0 12px}}@media (max-width:960px){.mat-tab-label{padding:0 12px}}.mat-tab-group[mat-stretch-tabs] .mat-tab-label,.mat-tab-group[md-stretch-tabs] .mat-tab-label{flex-basis:0;flex-grow:1}.mat-tab-body-wrapper{position:relative;overflow:hidden;display:flex;transition:height .5s cubic-bezier(.35,0,.25,1)}.mat-tab-body{top:0;left:0;right:0;bottom:0;position:absolute;display:block;overflow:hidden}.mat-tab-body.mat-tab-body-active{position:relative;overflow-x:hidden;overflow-y:auto;z-index:1;flex-grow:1}.mat-tab-group.mat-tab-group-dynamic-height .mat-tab-body.mat-tab-body-active{overflow-y:hidden}"],
                encapsulation: ViewEncapsulation.None,
                preserveWhitespaces: false,
                changeDetection: ChangeDetectionStrategy.OnPush,
                inputs: ['color', 'disableRipple'],
                host: {
                    'class': 'mat-tab-group',
                    '[class.mat-tab-group-dynamic-height]': 'dynamicHeight',
                    '[class.mat-tab-group-inverted-header]': 'headerPosition === "below"',
                },
                viewProviders: [{ provide: MATERIAL_COMPATIBILITY_MODE, useValue: true }],
            },] },
];
/**
 * @nocollapse
 */
MdTabGroup.ctorParameters = function () { return [
    { type: Renderer2, },
    { type: ElementRef, },
    { type: ChangeDetectorRef, },
]; };
MdTabGroup.propDecorators = {
    '_tabs': [{ type: ContentChildren, args: [MdTab,] },],
    '_tabBodyWrapper': [{ type: ViewChild, args: ['tabBodyWrapper',] },],
    'dynamicHeight': [{ type: Input },],
    '_dynamicHeightDeprecated': [{ type: Input, args: ['md-dynamic-height',] },],
    'selectedIndex': [{ type: Input },],
    'headerPosition': [{ type: Input },],
    'backgroundColor': [{ type: Input },],
    'selectedIndexChange': [{ type: Output },],
    'focusChange': [{ type: Output },],
    'selectChange': [{ type: Output },],
};
/**
 * \@docs-private
 */
var MdTabLabelWrapperBase = (function () {
    function MdTabLabelWrapperBase() {
    }
    return MdTabLabelWrapperBase;
}());
var _MdTabLabelWrapperMixinBase = mixinDisabled(MdTabLabelWrapperBase);
/**
 * Used in the `md-tab-group` view to display tab labels.
 * \@docs-private
 */
var MdTabLabelWrapper = (function (_super) {
    tslib_1.__extends(MdTabLabelWrapper, _super);
    /**
     * @param {?} elementRef
     */
    function MdTabLabelWrapper(elementRef) {
        var _this = _super.call(this) || this;
        _this.elementRef = elementRef;
        return _this;
    }
    /**
     * Sets focus on the wrapper element
     * @return {?}
     */
    MdTabLabelWrapper.prototype.focus = function () {
        this.elementRef.nativeElement.focus();
    };
    /**
     * @return {?}
     */
    MdTabLabelWrapper.prototype.getOffsetLeft = function () {
        return this.elementRef.nativeElement.offsetLeft;
    };
    /**
     * @return {?}
     */
    MdTabLabelWrapper.prototype.getOffsetWidth = function () {
        return this.elementRef.nativeElement.offsetWidth;
    };
    return MdTabLabelWrapper;
}(_MdTabLabelWrapperMixinBase));
MdTabLabelWrapper.decorators = [
    { type: Directive, args: [{
                selector: '[mdTabLabelWrapper], [matTabLabelWrapper]',
                inputs: ['disabled'],
                host: {
                    '[class.mat-tab-disabled]': 'disabled'
                }
            },] },
];
/**
 * @nocollapse
 */
MdTabLabelWrapper.ctorParameters = function () { return [
    { type: ElementRef, },
]; };
/**
 * The distance in pixels that will be overshot when scrolling a tab label into view. This helps
 * provide a small affordance to the label next to it.
 */
var EXAGGERATED_OVERSCROLL = 60;
/**
 * \@docs-private
 */
var MdTabHeaderBase = (function () {
    function MdTabHeaderBase() {
    }
    return MdTabHeaderBase;
}());
var _MdTabHeaderMixinBase = mixinDisableRipple(MdTabHeaderBase);
/**
 * The header of the tab group which displays a list of all the tabs in the tab group. Includes
 * an ink bar that follows the currently selected tab. When the tabs list's width exceeds the
 * width of the header container, then arrows will be displayed to allow the user to scroll
 * left and right across the header.
 * \@docs-private
 */
var MdTabHeader = (function (_super) {
    tslib_1.__extends(MdTabHeader, _super);
    /**
     * @param {?} _elementRef
     * @param {?} _renderer
     * @param {?} _changeDetectorRef
     * @param {?} _dir
     */
    function MdTabHeader(_elementRef, _renderer, _changeDetectorRef, _dir) {
        var _this = _super.call(this) || this;
        _this._elementRef = _elementRef;
        _this._renderer = _renderer;
        _this._changeDetectorRef = _changeDetectorRef;
        _this._dir = _dir;
        /**
         * The tab index that is focused.
         */
        _this._focusIndex = 0;
        /**
         * The distance in pixels that the tab labels should be translated to the left.
         */
        _this._scrollDistance = 0;
        /**
         * Whether the header should scroll to the selected index after the view has been checked.
         */
        _this._selectedIndexChanged = false;
        /**
         * Combines listeners that will re-align the ink bar whenever they're invoked.
         */
        _this._realignInkBar = Subscription.EMPTY;
        /**
         * Whether the controls for pagination should be displayed
         */
        _this._showPaginationControls = false;
        /**
         * Whether the tab list can be scrolled more towards the end of the tab label list.
         */
        _this._disableScrollAfter = true;
        /**
         * Whether the tab list can be scrolled more towards the beginning of the tab label list.
         */
        _this._disableScrollBefore = true;
        _this._selectedIndex = 0;
        /**
         * Event emitted when the option is selected.
         */
        _this.selectFocusedIndex = new EventEmitter();
        /**
         * Event emitted when a label is focused.
         */
        _this.indexFocused = new EventEmitter();
        return _this;
    }
    Object.defineProperty(MdTabHeader.prototype, "selectedIndex", {
        /**
         * The index of the active tab.
         * @return {?}
         */
        get: function () { return this._selectedIndex; },
        /**
         * @param {?} value
         * @return {?}
         */
        set: function (value) {
            this._selectedIndexChanged = this._selectedIndex != value;
            this._selectedIndex = value;
            this._focusIndex = value;
        },
        enumerable: true,
        configurable: true
    });
    /**
     * @return {?}
     */
    MdTabHeader.prototype.ngAfterContentChecked = function () {
        // If the number of tab labels have changed, check if scrolling should be enabled
        if (this._tabLabelCount != this._labelWrappers.length) {
            this._updatePagination();
            this._tabLabelCount = this._labelWrappers.length;
            this._changeDetectorRef.markForCheck();
        }
        // If the selected index has changed, scroll to the label and check if the scrolling controls
        // should be disabled.
        if (this._selectedIndexChanged) {
            this._scrollToLabel(this._selectedIndex);
            this._checkScrollingControls();
            this._alignInkBarToSelectedTab();
            this._selectedIndexChanged = false;
            this._changeDetectorRef.markForCheck();
        }
        // If the scroll distance has been changed (tab selected, focused, scroll controls activated),
        // then translate the header to reflect this.
        if (this._scrollDistanceChanged) {
            this._updateTabScrollPosition();
            this._scrollDistanceChanged = false;
            this._changeDetectorRef.markForCheck();
        }
    };
    /**
     * @param {?} event
     * @return {?}
     */
    MdTabHeader.prototype._handleKeydown = function (event) {
        switch (event.keyCode) {
            case RIGHT_ARROW:
                this._focusNextTab();
                break;
            case LEFT_ARROW:
                this._focusPreviousTab();
                break;
            case ENTER:
            case SPACE:
                this.selectFocusedIndex.emit(this.focusIndex);
                event.preventDefault();
                break;
        }
    };
    /**
     * Aligns the ink bar to the selected tab on load.
     * @return {?}
     */
    MdTabHeader.prototype.ngAfterContentInit = function () {
        var _this = this;
        var /** @type {?} */ dirChange = this._dir ? this._dir.change : of(null);
        var /** @type {?} */ resize = typeof window !== 'undefined' ?
            auditTime.call(fromEvent(window, 'resize'), 150) :
            of(null);
        this._realignInkBar = startWith.call(merge(dirChange, resize), null).subscribe(function () {
            _this._updatePagination();
            _this._alignInkBarToSelectedTab();
        });
    };
    /**
     * @return {?}
     */
    MdTabHeader.prototype.ngOnDestroy = function () {
        this._realignInkBar.unsubscribe();
    };
    /**
     * Callback for when the MutationObserver detects that the content has changed.
     * @return {?}
     */
    MdTabHeader.prototype._onContentChanges = function () {
        this._updatePagination();
        this._alignInkBarToSelectedTab();
        this._changeDetectorRef.markForCheck();
    };
    /**
     * Updating the view whether pagination should be enabled or not
     * @return {?}
     */
    MdTabHeader.prototype._updatePagination = function () {
        this._checkPaginationEnabled();
        this._checkScrollingControls();
        this._updateTabScrollPosition();
    };
    Object.defineProperty(MdTabHeader.prototype, "focusIndex", {
        /**
         * Tracks which element has focus; used for keyboard navigation
         * @return {?}
         */
        get: function () { return this._focusIndex; },
        /**
         * When the focus index is set, we must manually send focus to the correct label
         * @param {?} value
         * @return {?}
         */
        set: function (value) {
            if (!this._isValidIndex(value) || this._focusIndex == value) {
                return;
            }
            this._focusIndex = value;
            this.indexFocused.emit(value);
            this._setTabFocus(value);
        },
        enumerable: true,
        configurable: true
    });
    /**
     * Determines if an index is valid.  If the tabs are not ready yet, we assume that the user is
     * providing a valid index and return true.
     * @param {?} index
     * @return {?}
     */
    MdTabHeader.prototype._isValidIndex = function (index) {
        if (!this._labelWrappers) {
            return true;
        }
        var /** @type {?} */ tab = this._labelWrappers ? this._labelWrappers.toArray()[index] : null;
        return !!tab && !tab.disabled;
    };
    /**
     * Sets focus on the HTML element for the label wrapper and scrolls it into the view if
     * scrolling is enabled.
     * @param {?} tabIndex
     * @return {?}
     */
    MdTabHeader.prototype._setTabFocus = function (tabIndex) {
        if (this._showPaginationControls) {
            this._scrollToLabel(tabIndex);
        }
        if (this._labelWrappers && this._labelWrappers.length) {
            this._labelWrappers.toArray()[tabIndex].focus();
            // Do not let the browser manage scrolling to focus the element, this will be handled
            // by using translation. In LTR, the scroll left should be 0. In RTL, the scroll width
            // should be the full width minus the offset width.
            var /** @type {?} */ containerEl = this._tabListContainer.nativeElement;
            var /** @type {?} */ dir = this._getLayoutDirection();
            if (dir == 'ltr') {
                containerEl.scrollLeft = 0;
            }
            else {
                containerEl.scrollLeft = containerEl.scrollWidth - containerEl.offsetWidth;
            }
        }
    };
    /**
     * Moves the focus towards the beginning or the end of the list depending on the offset provided.
     * Valid offsets are 1 and -1.
     * @param {?} offset
     * @return {?}
     */
    MdTabHeader.prototype._moveFocus = function (offset) {
        if (this._labelWrappers) {
            var /** @type {?} */ tabs = this._labelWrappers.toArray();
            for (var /** @type {?} */ i = this.focusIndex + offset; i < tabs.length && i >= 0; i += offset) {
                if (this._isValidIndex(i)) {
                    this.focusIndex = i;
                    return;
                }
            }
        }
    };
    /**
     * Increment the focus index by 1 until a valid tab is found.
     * @return {?}
     */
    MdTabHeader.prototype._focusNextTab = function () {
        this._moveFocus(this._getLayoutDirection() == 'ltr' ? 1 : -1);
    };
    /**
     * Decrement the focus index by 1 until a valid tab is found.
     * @return {?}
     */
    MdTabHeader.prototype._focusPreviousTab = function () {
        this._moveFocus(this._getLayoutDirection() == 'ltr' ? -1 : 1);
    };
    /**
     * The layout direction of the containing app.
     * @return {?}
     */
    MdTabHeader.prototype._getLayoutDirection = function () {
        return this._dir && this._dir.value === 'rtl' ? 'rtl' : 'ltr';
    };
    /**
     * Performs the CSS transformation on the tab list that will cause the list to scroll.
     * @return {?}
     */
    MdTabHeader.prototype._updateTabScrollPosition = function () {
        var /** @type {?} */ scrollDistance = this.scrollDistance;
        var /** @type {?} */ translateX = this._getLayoutDirection() === 'ltr' ? -scrollDistance : scrollDistance;
        this._renderer.setStyle(this._tabList.nativeElement, 'transform', "translate3d(" + translateX + "px, 0, 0)");
    };
    Object.defineProperty(MdTabHeader.prototype, "scrollDistance", {
        /**
         * @return {?}
         */
        get: function () { return this._scrollDistance; },
        /**
         * Sets the distance in pixels that the tab header should be transformed in the X-axis.
         * @param {?} v
         * @return {?}
         */
        set: function (v) {
            this._scrollDistance = Math.max(0, Math.min(this._getMaxScrollDistance(), v));
            // Mark that the scroll distance has changed so that after the view is checked, the CSS
            // transformation can move the header.
            this._scrollDistanceChanged = true;
            this._checkScrollingControls();
        },
        enumerable: true,
        configurable: true
    });
    /**
     * Moves the tab list in the 'before' or 'after' direction (towards the beginning of the list or
     * the end of the list, respectively). The distance to scroll is computed to be a third of the
     * length of the tab list view window.
     *
     * This is an expensive call that forces a layout reflow to compute box and scroll metrics and
     * should be called sparingly.
     * @param {?} scrollDir
     * @return {?}
     */
    MdTabHeader.prototype._scrollHeader = function (scrollDir) {
        var /** @type {?} */ viewLength = this._tabListContainer.nativeElement.offsetWidth;
        // Move the scroll distance one-third the length of the tab list's viewport.
        this.scrollDistance += (scrollDir == 'before' ? -1 : 1) * viewLength / 3;
    };
    /**
     * Moves the tab list such that the desired tab label (marked by index) is moved into view.
     *
     * This is an expensive call that forces a layout reflow to compute box and scroll metrics and
     * should be called sparingly.
     * @param {?} labelIndex
     * @return {?}
     */
    MdTabHeader.prototype._scrollToLabel = function (labelIndex) {
        var /** @type {?} */ selectedLabel = this._labelWrappers ? this._labelWrappers.toArray()[labelIndex] : null;
        if (!selectedLabel) {
            return;
        }
        // The view length is the visible width of the tab labels.
        var /** @type {?} */ viewLength = this._tabListContainer.nativeElement.offsetWidth;
        var /** @type {?} */ labelBeforePos, /** @type {?} */ labelAfterPos;
        if (this._getLayoutDirection() == 'ltr') {
            labelBeforePos = selectedLabel.getOffsetLeft();
            labelAfterPos = labelBeforePos + selectedLabel.getOffsetWidth();
        }
        else {
            labelAfterPos = this._tabList.nativeElement.offsetWidth - selectedLabel.getOffsetLeft();
            labelBeforePos = labelAfterPos - selectedLabel.getOffsetWidth();
        }
        var /** @type {?} */ beforeVisiblePos = this.scrollDistance;
        var /** @type {?} */ afterVisiblePos = this.scrollDistance + viewLength;
        if (labelBeforePos < beforeVisiblePos) {
            // Scroll header to move label to the before direction
            this.scrollDistance -= beforeVisiblePos - labelBeforePos + EXAGGERATED_OVERSCROLL;
        }
        else if (labelAfterPos > afterVisiblePos) {
            // Scroll header to move label to the after direction
            this.scrollDistance += labelAfterPos - afterVisiblePos + EXAGGERATED_OVERSCROLL;
        }
    };
    /**
     * Evaluate whether the pagination controls should be displayed. If the scroll width of the
     * tab list is wider than the size of the header container, then the pagination controls should
     * be shown.
     *
     * This is an expensive call that forces a layout reflow to compute box and scroll metrics and
     * should be called sparingly.
     * @return {?}
     */
    MdTabHeader.prototype._checkPaginationEnabled = function () {
        var /** @type {?} */ isEnabled = this._tabList.nativeElement.scrollWidth > this._elementRef.nativeElement.offsetWidth;
        if (!isEnabled) {
            this.scrollDistance = 0;
        }
        if (isEnabled !== this._showPaginationControls) {
            this._changeDetectorRef.markForCheck();
        }
        this._showPaginationControls = isEnabled;
    };
    /**
     * Evaluate whether the before and after controls should be enabled or disabled.
     * If the header is at the beginning of the list (scroll distance is equal to 0) then disable the
     * before button. If the header is at the end of the list (scroll distance is equal to the
     * maximum distance we can scroll), then disable the after button.
     *
     * This is an expensive call that forces a layout reflow to compute box and scroll metrics and
     * should be called sparingly.
     * @return {?}
     */
    MdTabHeader.prototype._checkScrollingControls = function () {
        // Check if the pagination arrows should be activated.
        this._disableScrollBefore = this.scrollDistance == 0;
        this._disableScrollAfter = this.scrollDistance == this._getMaxScrollDistance();
        this._changeDetectorRef.markForCheck();
    };
    /**
     * Determines what is the maximum length in pixels that can be set for the scroll distance. This
     * is equal to the difference in width between the tab list container and tab header container.
     *
     * This is an expensive call that forces a layout reflow to compute box and scroll metrics and
     * should be called sparingly.
     * @return {?}
     */
    MdTabHeader.prototype._getMaxScrollDistance = function () {
        var /** @type {?} */ lengthOfTabList = this._tabList.nativeElement.scrollWidth;
        var /** @type {?} */ viewLength = this._tabListContainer.nativeElement.offsetWidth;
        return (lengthOfTabList - viewLength) || 0;
    };
    /**
     * Tells the ink-bar to align itself to the current label wrapper
     * @return {?}
     */
    MdTabHeader.prototype._alignInkBarToSelectedTab = function () {
        var /** @type {?} */ selectedLabelWrapper = this._labelWrappers && this._labelWrappers.length ?
            this._labelWrappers.toArray()[this.selectedIndex].elementRef.nativeElement :
            null;
        this._inkBar.alignToElement(selectedLabelWrapper);
    };
    return MdTabHeader;
}(_MdTabHeaderMixinBase));
MdTabHeader.decorators = [
    { type: Component, args: [{ selector: 'md-tab-header, mat-tab-header',
                template: "<div class=\"mat-tab-header-pagination mat-tab-header-pagination-before mat-elevation-z4\" aria-hidden=\"true\" mat-ripple [matRippleDisabled]=\"_disableScrollBefore || disableRipple\" [class.mat-tab-header-pagination-disabled]=\"_disableScrollBefore\" (click)=\"_scrollHeader('before')\"><div class=\"mat-tab-header-pagination-chevron\"></div></div><div class=\"mat-tab-label-container\" #tabListContainer (keydown)=\"_handleKeydown($event)\"><div class=\"mat-tab-list\" #tabList role=\"tablist\" (cdkObserveContent)=\"_onContentChanges()\"><div class=\"mat-tab-labels\"><ng-content></ng-content></div><mat-ink-bar></mat-ink-bar></div></div><div class=\"mat-tab-header-pagination mat-tab-header-pagination-after mat-elevation-z4\" aria-hidden=\"true\" mat-ripple [matRippleDisabled]=\"_disableScrollAfter || disableRipple\" [class.mat-tab-header-pagination-disabled]=\"_disableScrollAfter\" (click)=\"_scrollHeader('after')\"><div class=\"mat-tab-header-pagination-chevron\"></div></div>",
                styles: [".mat-tab-header{display:flex;overflow:hidden;position:relative;flex-shrink:0}.mat-tab-label{height:48px;padding:0 24px;cursor:pointer;box-sizing:border-box;opacity:.6;min-width:160px;text-align:center;display:inline-flex;justify-content:center;align-items:center;white-space:nowrap;position:relative}.mat-tab-label:focus{outline:0;opacity:1}.mat-tab-label.mat-tab-disabled{cursor:default;pointer-events:none}@media (max-width:600px){.mat-tab-label{min-width:72px}}.mat-ink-bar{position:absolute;bottom:0;height:2px;transition:.5s cubic-bezier(.35,0,.25,1)}.mat-tab-group-inverted-header .mat-ink-bar{bottom:auto;top:0}.mat-tab-header-pagination{position:relative;display:none;justify-content:center;align-items:center;min-width:32px;cursor:pointer;z-index:2}.mat-tab-header-pagination-controls-enabled .mat-tab-header-pagination{display:flex}.mat-tab-header-pagination-before,.mat-tab-header-rtl .mat-tab-header-pagination-after{padding-left:4px}.mat-tab-header-pagination-before .mat-tab-header-pagination-chevron,.mat-tab-header-rtl .mat-tab-header-pagination-after .mat-tab-header-pagination-chevron{transform:rotate(-135deg)}.mat-tab-header-pagination-after,.mat-tab-header-rtl .mat-tab-header-pagination-before{padding-right:4px}.mat-tab-header-pagination-after .mat-tab-header-pagination-chevron,.mat-tab-header-rtl .mat-tab-header-pagination-before .mat-tab-header-pagination-chevron{transform:rotate(45deg)}.mat-tab-header-pagination-chevron{border-style:solid;border-width:2px 2px 0 0;content:'';height:8px;width:8px}.mat-tab-header-pagination-disabled{box-shadow:none;cursor:default}.mat-tab-label-container{display:flex;flex-grow:1;overflow:hidden;z-index:1}.mat-tab-list{flex-grow:1;position:relative;transition:transform .5s cubic-bezier(.35,0,.25,1)}.mat-tab-labels{display:flex}"],
                inputs: ['disableRipple'],
                encapsulation: ViewEncapsulation.None,
                preserveWhitespaces: false,
                changeDetection: ChangeDetectionStrategy.OnPush,
                host: {
                    'class': 'mat-tab-header',
                    '[class.mat-tab-header-pagination-controls-enabled]': '_showPaginationControls',
                    '[class.mat-tab-header-rtl]': "_getLayoutDirection() == 'rtl'",
                },
                viewProviders: [{ provide: MATERIAL_COMPATIBILITY_MODE, useValue: true }],
            },] },
];
/**
 * @nocollapse
 */
MdTabHeader.ctorParameters = function () { return [
    { type: ElementRef, },
    { type: Renderer2, },
    { type: ChangeDetectorRef, },
    { type: Directionality, decorators: [{ type: Optional },] },
]; };
MdTabHeader.propDecorators = {
    '_labelWrappers': [{ type: ContentChildren, args: [MdTabLabelWrapper,] },],
    '_inkBar': [{ type: ViewChild, args: [MdInkBar,] },],
    '_tabListContainer': [{ type: ViewChild, args: ['tabListContainer',] },],
    '_tabList': [{ type: ViewChild, args: ['tabList',] },],
    'selectedIndex': [{ type: Input },],
    'selectFocusedIndex': [{ type: Output },],
    'indexFocused': [{ type: Output },],
};
/**
 * \@docs-private
 */
var MdTabNavBase = (function () {
    /**
     * @param {?} _renderer
     * @param {?} _elementRef
     */
    function MdTabNavBase(_renderer, _elementRef) {
        this._renderer = _renderer;
        this._elementRef = _elementRef;
    }
    return MdTabNavBase;
}());
var _MdTabNavMixinBase = mixinDisableRipple(mixinColor(MdTabNavBase, 'primary'));
/**
 * Navigation component matching the styles of the tab group header.
 * Provides anchored navigation with animated ink bar.
 */
var MdTabNav = (function (_super) {
    tslib_1.__extends(MdTabNav, _super);
    /**
     * @param {?} renderer
     * @param {?} elementRef
     * @param {?} _dir
     * @param {?} _ngZone
     * @param {?} _changeDetectorRef
     */
    function MdTabNav(renderer, elementRef, _dir, _ngZone, _changeDetectorRef) {
        var _this = _super.call(this, renderer, elementRef) || this;
        _this._dir = _dir;
        _this._ngZone = _ngZone;
        _this._changeDetectorRef = _changeDetectorRef;
        /**
         * Subject that emits when the component has been destroyed.
         */
        _this._onDestroy = new Subject();
        _this._disableRipple = false;
        return _this;
    }
    Object.defineProperty(MdTabNav.prototype, "backgroundColor", {
        /**
         * Background color of the tab nav.
         * @return {?}
         */
        get: function () { return this._backgroundColor; },
        /**
         * @param {?} value
         * @return {?}
         */
        set: function (value) {
            var /** @type {?} */ nativeElement = this._elementRef.nativeElement;
            this._renderer.removeClass(nativeElement, "mat-background-" + this.backgroundColor);
            if (value) {
                this._renderer.addClass(nativeElement, "mat-background-" + value);
            }
            this._backgroundColor = value;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdTabNav.prototype, "disableRipple", {
        /**
         * Whether ripples should be disabled for all links or not.
         * @return {?}
         */
        get: function () { return this._disableRipple; },
        /**
         * @param {?} value
         * @return {?}
         */
        set: function (value) {
            this._disableRipple = coerceBooleanProperty(value);
            this._setLinkDisableRipple();
        },
        enumerable: true,
        configurable: true
    });
    /**
     * Notifies the component that the active link has been changed.
     * @param {?} element
     * @return {?}
     */
    MdTabNav.prototype.updateActiveLink = function (element) {
        this._activeLinkChanged = this._activeLinkElement != element;
        this._activeLinkElement = element;
        if (this._activeLinkChanged) {
            this._changeDetectorRef.markForCheck();
        }
    };
    /**
     * @return {?}
     */
    MdTabNav.prototype.ngAfterContentInit = function () {
        var _this = this;
        this._ngZone.runOutsideAngular(function () {
            var /** @type {?} */ dirChange = _this._dir ? _this._dir.change : of(null);
            var /** @type {?} */ resize = typeof window !== 'undefined' ?
                auditTime.call(fromEvent(window, 'resize'), 10) :
                of(null);
            return takeUntil.call(merge(dirChange, resize), _this._onDestroy).subscribe(function () {
                _this._alignInkBar();
            });
        });
        this._setLinkDisableRipple();
    };
    /**
     * Checks if the active link has been changed and, if so, will update the ink bar.
     * @return {?}
     */
    MdTabNav.prototype.ngAfterContentChecked = function () {
        if (this._activeLinkChanged) {
            this._alignInkBar();
            this._activeLinkChanged = false;
        }
    };
    /**
     * @return {?}
     */
    MdTabNav.prototype.ngOnDestroy = function () {
        this._onDestroy.next();
        this._onDestroy.complete();
    };
    /**
     * Aligns the ink bar to the active link.
     * @return {?}
     */
    MdTabNav.prototype._alignInkBar = function () {
        if (this._activeLinkElement) {
            this._inkBar.alignToElement(this._activeLinkElement.nativeElement);
        }
    };
    /**
     * Sets the `disableRipple` property on each link of the navigation bar.
     * @return {?}
     */
    MdTabNav.prototype._setLinkDisableRipple = function () {
        var _this = this;
        if (this._tabLinks) {
            this._tabLinks.forEach(function (link) { return link.disableRipple = _this.disableRipple; });
        }
    };
    return MdTabNav;
}(_MdTabNavMixinBase));
MdTabNav.decorators = [
    { type: Component, args: [{ selector: '[md-tab-nav-bar], [mat-tab-nav-bar]',
                inputs: ['color', 'disableRipple'],
                template: "<div class=\"mat-tab-links\" (cdkObserveContent)=\"_alignInkBar()\"><ng-content></ng-content><mat-ink-bar></mat-ink-bar></div>",
                styles: [".mat-tab-nav-bar{overflow:hidden;position:relative;flex-shrink:0}.mat-tab-links{position:relative}.mat-tab-link{height:48px;padding:0 24px;cursor:pointer;box-sizing:border-box;opacity:.6;min-width:160px;text-align:center;display:inline-flex;justify-content:center;align-items:center;white-space:nowrap;vertical-align:top;text-decoration:none;position:relative;overflow:hidden}.mat-tab-link:focus{outline:0;opacity:1}.mat-tab-link.mat-tab-disabled{cursor:default;pointer-events:none}@media (max-width:600px){.mat-tab-link{min-width:72px}}.mat-ink-bar{position:absolute;bottom:0;height:2px;transition:.5s cubic-bezier(.35,0,.25,1)}.mat-tab-group-inverted-header .mat-ink-bar{bottom:auto;top:0}"],
                host: { 'class': 'mat-tab-nav-bar' },
                encapsulation: ViewEncapsulation.None,
                preserveWhitespaces: false,
                changeDetection: ChangeDetectionStrategy.OnPush,
                viewProviders: [{ provide: MATERIAL_COMPATIBILITY_MODE, useValue: true }],
            },] },
];
/**
 * @nocollapse
 */
MdTabNav.ctorParameters = function () { return [
    { type: Renderer2, },
    { type: ElementRef, },
    { type: Directionality, decorators: [{ type: Optional },] },
    { type: NgZone, },
    { type: ChangeDetectorRef, },
]; };
MdTabNav.propDecorators = {
    '_inkBar': [{ type: ViewChild, args: [MdInkBar,] },],
    '_tabLinks': [{ type: ContentChildren, args: [forwardRef(function () { return MdTabLink; }), { descendants: true },] },],
    'backgroundColor': [{ type: Input },],
};
var MdTabLinkBase = (function () {
    function MdTabLinkBase() {
    }
    return MdTabLinkBase;
}());
var _MdTabLinkMixinBase = mixinDisabled(MdTabLinkBase);
/**
 * Link inside of a `md-tab-nav-bar`.
 */
var MdTabLink = (function (_super) {
    tslib_1.__extends(MdTabLink, _super);
    /**
     * @param {?} _mdTabNavBar
     * @param {?} _elementRef
     * @param {?} ngZone
     * @param {?} ruler
     * @param {?} platform
     * @param {?} globalOptions
     */
    function MdTabLink(_mdTabNavBar, _elementRef, ngZone, ruler, platform, globalOptions) {
        var _this = _super.call(this) || this;
        _this._mdTabNavBar = _mdTabNavBar;
        _this._elementRef = _elementRef;
        /**
         * Whether the tab link is active or not.
         */
        _this._isActive = false;
        /**
         * Whether the ripples for this tab should be disabled or not.
         */
        _this._disableRipple = false;
        // Manually create a ripple instance that uses the tab link element as trigger element.
        // Notice that the lifecycle hooks for the ripple config won't be called anymore.
        _this._tabLinkRipple = new MdRipple(_elementRef, ngZone, ruler, platform, globalOptions);
        return _this;
    }
    Object.defineProperty(MdTabLink.prototype, "active", {
        /**
         * Whether the link is active.
         * @return {?}
         */
        get: function () { return this._isActive; },
        /**
         * @param {?} value
         * @return {?}
         */
        set: function (value) {
            this._isActive = value;
            if (value) {
                this._mdTabNavBar.updateActiveLink(this._elementRef);
            }
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdTabLink.prototype, "disableRipple", {
        /**
         * Whether ripples should be disabled or not.
         * @return {?}
         */
        get: function () { return this._disableRipple; },
        /**
         * @param {?} value
         * @return {?}
         */
        set: function (value) {
            this._disableRipple = value;
            this._tabLinkRipple.disabled = this.disableRipple;
            this._tabLinkRipple._updateRippleRenderer();
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdTabLink.prototype, "tabIndex", {
        /**
         * \@docs-private
         * @return {?}
         */
        get: function () {
            return this.disabled ? -1 : 0;
        },
        enumerable: true,
        configurable: true
    });
    /**
     * @return {?}
     */
    MdTabLink.prototype.ngOnDestroy = function () {
        // Manually call the ngOnDestroy lifecycle hook of the ripple instance because it won't be
        // called automatically since its instance is not created by Angular.
        this._tabLinkRipple.ngOnDestroy();
    };
    return MdTabLink;
}(_MdTabLinkMixinBase));
MdTabLink.decorators = [
    { type: Directive, args: [{
                selector: '[md-tab-link], [mat-tab-link], [mdTabLink], [matTabLink]',
                inputs: ['disabled'],
                host: {
                    'class': 'mat-tab-link',
                    '[attr.aria-disabled]': 'disabled.toString()',
                    '[attr.tabindex]': 'tabIndex',
                    '[class.mat-tab-disabled]': 'disabled'
                }
            },] },
];
/**
 * @nocollapse
 */
MdTabLink.ctorParameters = function () { return [
    { type: MdTabNav, },
    { type: ElementRef, },
    { type: NgZone, },
    { type: ViewportRuler, },
    { type: Platform, },
    { type: undefined, decorators: [{ type: Optional }, { type: Inject, args: [MD_RIPPLE_GLOBAL_OPTIONS,] },] },
]; };
MdTabLink.propDecorators = {
    'active': [{ type: Input },],
};
var MdTabsModule = (function () {
    function MdTabsModule() {
    }
    return MdTabsModule;
}());
MdTabsModule.decorators = [
    { type: NgModule, args: [{
                imports: [
                    CommonModule,
                    MdCommonModule,
                    PortalModule,
                    MdRippleModule,
                    ObserversModule,
                    ScrollDispatchModule,
                ],
                // Don't export all components because some are only to be used internally.
                exports: [
                    MdCommonModule,
                    MdTabGroup,
                    MdTabLabel,
                    MdTab,
                    MdTabNav,
                    MdTabLink,
                ],
                declarations: [
                    MdTabGroup,
                    MdTabLabel,
                    MdTab,
                    MdInkBar,
                    MdTabLabelWrapper,
                    MdTabNav,
                    MdTabLink,
                    MdTabBody,
                    MdTabHeader
                ],
                providers: [VIEWPORT_RULER_PROVIDER],
            },] },
];
/**
 * @nocollapse
 */
MdTabsModule.ctorParameters = function () { return []; };
/**
 * Generated bundle index. Do not edit.
 */
export { MdInkBar, MdTabBody, MdTabHeader, MdTabLabelWrapper, MdTab, MdTabLabel, MdTabNav, MdTabLink, MdTabsModule, MdTabChangeEvent, MdTabGroupBase, _MdTabGroupMixinBase, MdTabGroup, MdInkBar as MatInkBar, MdTab as MatTab, MdTabBody as MatTabBody, MdTabChangeEvent as MatTabChangeEvent, MdTabGroup as MatTabGroup, MdTabGroupBase as MatTabGroupBase, MdTabHeader as MatTabHeader, MdTabLabel as MatTabLabel, MdTabLabelWrapper as MatTabLabelWrapper, MdTabLink as MatTabLink, MdTabNav as MatTabNav, MdTabsModule as MatTabsModule, MdTabBase as ɵe18, _MdTabMixinBase as ɵf18, MdTabHeaderBase as ɵa18, _MdTabHeaderMixinBase as ɵb18, MdTabLabelWrapperBase as ɵc18, _MdTabLabelWrapperMixinBase as ɵd18, MdTabLinkBase as ɵi18, MdTabNavBase as ɵg18, _MdTabLinkMixinBase as ɵj18, _MdTabNavMixinBase as ɵh18 };
//# sourceMappingURL=tabs.es5.js.map
