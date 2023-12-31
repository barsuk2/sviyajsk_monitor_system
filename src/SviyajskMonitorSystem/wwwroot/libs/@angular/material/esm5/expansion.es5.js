import * as tslib_1 from "tslib";
/**
 * @license
 * Copyright Google Inc. All Rights Reserved.
 *
 * Use of this source code is governed by an MIT-style license that can be
 * found in the LICENSE file at https://angular.io/license
 */
import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, Directive, ElementRef, EventEmitter, Host, Injectable, Input, NgModule, Optional, Output, Renderer2, ViewEncapsulation, forwardRef } from '@angular/core';
import { CompatibilityModule, ENTER, SPACE, UNIQUE_SELECTION_DISPATCHER_PROVIDER, UniqueSelectionDispatcher, filter, mixinDisabled } from '@angular/material/core';
import { A11yModule, FocusMonitor } from '@angular/cdk/a11y';
import { coerceBooleanProperty } from '@angular/cdk/coercion';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { Subject } from 'rxjs/Subject';
import { merge } from 'rxjs/observable/merge';
import { Subscription } from 'rxjs/Subscription';
/**
 * Unique ID counter
 */
var nextId = 0;
/**
 * Directive whose purpose is to manage the expanded state of CdkAccordionItem children.
 */
var CdkAccordion = (function () {
    function CdkAccordion() {
        /**
         * A readonly id value to use for unique selection coordination.
         */
        this.id = "cdk-accordion-" + nextId++;
        this._multi = false;
        this._hideToggle = false;
        /**
         * The display mode used for all expansion panels in the accordion. Currently two display
         * modes exist:
         *   default - a gutter-like spacing is placed around any expanded panel, placing the expanded
         *     panel at a different elevation from the reset of the accordion.
         *  flat - no spacing is placed around expanded panels, showing all panels at the same
         *     elevation.
         */
        this.displayMode = 'default';
    }
    Object.defineProperty(CdkAccordion.prototype, "multi", {
        /**
         * Whether the accordion should allow multiple expanded accordion items simulateously.
         * @return {?}
         */
        get: function () { return this._multi; },
        /**
         * @param {?} multi
         * @return {?}
         */
        set: function (multi) { this._multi = coerceBooleanProperty(multi); },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(CdkAccordion.prototype, "hideToggle", {
        /**
         * Whether the expansion indicator should be hidden.
         * @return {?}
         */
        get: function () { return this._hideToggle; },
        /**
         * @param {?} show
         * @return {?}
         */
        set: function (show) { this._hideToggle = coerceBooleanProperty(show); },
        enumerable: true,
        configurable: true
    });
    return CdkAccordion;
}());
CdkAccordion.decorators = [
    { type: Directive, args: [{
                selector: 'cdk-accordion, [cdk-accordion]',
            },] },
];
/**
 * @nocollapse
 */
CdkAccordion.ctorParameters = function () { return []; };
CdkAccordion.propDecorators = {
    'multi': [{ type: Input },],
    'hideToggle': [{ type: Input },],
    'displayMode': [{ type: Input },],
};
/**
 * Directive for a Material Design Accordion.
 */
var MdAccordion = (function (_super) {
    tslib_1.__extends(MdAccordion, _super);
    function MdAccordion() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    return MdAccordion;
}(CdkAccordion));
MdAccordion.decorators = [
    { type: Directive, args: [{
                selector: 'mat-accordion, md-accordion',
                host: {
                    class: 'mat-accordion'
                }
            },] },
];
/**
 * @nocollapse
 */
MdAccordion.ctorParameters = function () { return []; };
/**
 * Used to generate unique ID for each expansion panel.
 */
var nextId$1 = 0;
/**
 * An abstract class to be extended and decorated as a component.  Sets up all
 * events and attributes needed to be managed by a CdkAccordion parent.
 */
var AccordionItem = (function () {
    /**
     * @param {?} accordion
     * @param {?} _changeDetectorRef
     * @param {?} _expansionDispatcher
     */
    function AccordionItem(accordion, _changeDetectorRef, _expansionDispatcher) {
        var _this = this;
        this.accordion = accordion;
        this._changeDetectorRef = _changeDetectorRef;
        this._expansionDispatcher = _expansionDispatcher;
        /**
         * Event emitted every time the AccordionItem is closed.
         */
        this.closed = new EventEmitter();
        /**
         * Event emitted every time the AccordionItem is opened.
         */
        this.opened = new EventEmitter();
        /**
         * Event emitted when the AccordionItem is destroyed.
         */
        this.destroyed = new EventEmitter();
        /**
         * The unique AccordionItem id.
         */
        this.id = "cdk-accordion-child-" + nextId$1++;
        /**
         * Unregister function for _expansionDispatcher *
         */
        this._removeUniqueSelectionListener = function () { };
        this._removeUniqueSelectionListener =
            _expansionDispatcher.listen(function (id, accordionId) {
                if (_this.accordion && !_this.accordion.multi &&
                    _this.accordion.id === accordionId && _this.id !== id) {
                    _this.expanded = false;
                }
            });
    }
    Object.defineProperty(AccordionItem.prototype, "expanded", {
        /**
         * Whether the AccordionItem is expanded.
         * @return {?}
         */
        get: function () { return this._expanded; },
        /**
         * @param {?} expanded
         * @return {?}
         */
        set: function (expanded) {
            // Only emit events and update the internal value if the value changes.
            if (this._expanded !== expanded) {
                this._expanded = expanded;
                if (expanded) {
                    this.opened.emit();
                    /**
                     * In the unique selection dispatcher, the id parameter is the id of the CdkAccordionItem,
                     * the name value is the id of the accordion.
                     */
                    var accordionId = this.accordion ? this.accordion.id : this.id;
                    this._expansionDispatcher.notify(this.id, accordionId);
                }
                else {
                    this.closed.emit();
                }
                // Ensures that the animation will run when the value is set outside of an `@Input`.
                // This includes cases like the open, close and toggle methods.
                this._changeDetectorRef.markForCheck();
            }
        },
        enumerable: true,
        configurable: true
    });
    /**
     * Emits an event for the accordion item being destroyed.
     * @return {?}
     */
    AccordionItem.prototype.ngOnDestroy = function () {
        this.destroyed.emit();
        this._removeUniqueSelectionListener();
    };
    /**
     * Toggles the expanded state of the accordion item.
     * @return {?}
     */
    AccordionItem.prototype.toggle = function () {
        this.expanded = !this.expanded;
    };
    /**
     * Sets the expanded state of the accordion item to false.
     * @return {?}
     */
    AccordionItem.prototype.close = function () {
        this.expanded = false;
    };
    /**
     * Sets the expanded state of the accordion item to true.
     * @return {?}
     */
    AccordionItem.prototype.open = function () {
        this.expanded = true;
    };
    return AccordionItem;
}());
AccordionItem.decorators = [
    { type: Injectable },
];
/**
 * @nocollapse
 */
AccordionItem.ctorParameters = function () { return [
    { type: CdkAccordion, decorators: [{ type: Optional },] },
    { type: ChangeDetectorRef, },
    { type: UniqueSelectionDispatcher, },
]; };
AccordionItem.propDecorators = {
    'closed': [{ type: Output },],
    'opened': [{ type: Output },],
    'destroyed': [{ type: Output },],
    'expanded': [{ type: Input },],
};
/**
 * \@docs-private
 */
var MdExpansionPanelBase = (function (_super) {
    tslib_1.__extends(MdExpansionPanelBase, _super);
    /**
     * @param {?} accordion
     * @param {?} _changeDetectorRef
     * @param {?} _uniqueSelectionDispatcher
     */
    function MdExpansionPanelBase(accordion, _changeDetectorRef, _uniqueSelectionDispatcher) {
        return _super.call(this, accordion, _changeDetectorRef, _uniqueSelectionDispatcher) || this;
    }
    return MdExpansionPanelBase;
}(AccordionItem));
var _MdExpansionPanelMixinBase = mixinDisabled(MdExpansionPanelBase);
/**
 * Time and timing curve for expansion panel animations.
 */
var EXPANSION_PANEL_ANIMATION_TIMING = '225ms cubic-bezier(0.4,0.0,0.2,1)';
/**
 * <md-expansion-panel> component.
 *
 * This component can be used as a single element to show expandable content, or as one of
 * multiple children of an element with the CdkAccordion directive attached.
 *
 * Please refer to README.md for examples on how to use it.
 */
var MdExpansionPanel = (function (_super) {
    tslib_1.__extends(MdExpansionPanel, _super);
    /**
     * @param {?} accordion
     * @param {?} _changeDetectorRef
     * @param {?} _uniqueSelectionDispatcher
     */
    function MdExpansionPanel(accordion, _changeDetectorRef, _uniqueSelectionDispatcher) {
        var _this = _super.call(this, accordion, _changeDetectorRef, _uniqueSelectionDispatcher) || this;
        /**
         * Whether the toggle indicator should be hidden.
         */
        _this.hideToggle = false;
        /**
         * Stream that emits for changes in `\@Input` properties.
         */
        _this._inputChanges = new Subject();
        _this.accordion = accordion;
        return _this;
    }
    /**
     * Whether the expansion indicator should be hidden.
     * @return {?}
     */
    MdExpansionPanel.prototype._getHideToggle = function () {
        if (this.accordion) {
            return this.accordion.hideToggle;
        }
        return this.hideToggle;
    };
    /**
     * Determines whether the expansion panel should have spacing between it and its siblings.
     * @return {?}
     */
    MdExpansionPanel.prototype._hasSpacing = function () {
        if (this.accordion) {
            return (this.expanded ? this.accordion.displayMode : this._getExpandedState()) === 'default';
        }
        return false;
    };
    /**
     * Gets the expanded state string.
     * @return {?}
     */
    MdExpansionPanel.prototype._getExpandedState = function () {
        return this.expanded ? 'expanded' : 'collapsed';
    };
    /**
     * @param {?} changes
     * @return {?}
     */
    MdExpansionPanel.prototype.ngOnChanges = function (changes) {
        this._inputChanges.next(changes);
    };
    /**
     * @return {?}
     */
    MdExpansionPanel.prototype.ngOnDestroy = function () {
        this._inputChanges.complete();
    };
    return MdExpansionPanel;
}(_MdExpansionPanelMixinBase));
MdExpansionPanel.decorators = [
    { type: Component, args: [{ styles: [".mat-expansion-panel{transition:box-shadow 280ms cubic-bezier(.4,0,.2,1);box-sizing:content-box;display:block;margin:0;transition:margin 225ms cubic-bezier(.4,0,.2,1)}.mat-expansion-panel:not([class*=mat-elevation-z]){box-shadow:0 3px 1px -2px rgba(0,0,0,.2),0 2px 2px 0 rgba(0,0,0,.14),0 1px 5px 0 rgba(0,0,0,.12)}.mat-expansion-panel-content{overflow:hidden}.mat-expansion-panel-body{padding:0 24px 16px}.mat-expansion-panel-spacing{margin:16px 0}.mat-accordion .mat-expansion-panel-spacing:first-child{margin-top:0}.mat-accordion .mat-expansion-panel-spacing:last-child{margin-bottom:0}.mat-action-row{border-top-style:solid;border-top-width:1px;display:flex;flex-direction:row;justify-content:flex-end;padding:16px 8px 16px 24px}.mat-action-row button.mat-button{margin-left:8px}[dir=rtl] .mat-action-row button.mat-button{margin-left:0;margin-right:8px}"],
                selector: 'md-expansion-panel, mat-expansion-panel',
                template: "<ng-content select=\"mat-expansion-panel-header, md-expansion-panel-header\"></ng-content><div [class.mat-expanded]=\"expanded\" class=\"mat-expansion-panel-content\" [@bodyExpansion]=\"_getExpandedState()\" [id]=\"id\"><div class=\"mat-expansion-panel-body\"><ng-content></ng-content></div><ng-content select=\"mat-action-row, md-action-row\"></ng-content></div>",
                encapsulation: ViewEncapsulation.None,
                preserveWhitespaces: false,
                changeDetection: ChangeDetectionStrategy.OnPush,
                inputs: ['disabled', 'expanded'],
                host: {
                    'class': 'mat-expansion-panel',
                    '[class.mat-expanded]': 'expanded',
                    '[class.mat-expansion-panel-spacing]': '_hasSpacing()',
                },
                providers: [
                    { provide: AccordionItem, useExisting: forwardRef(function () { return MdExpansionPanel; }) }
                ],
                animations: [
                    trigger('bodyExpansion', [
                        state('collapsed', style({ height: '0px', visibility: 'hidden' })),
                        state('expanded', style({ height: '*', visibility: 'visible' })),
                        transition('expanded <=> collapsed', animate(EXPANSION_PANEL_ANIMATION_TIMING)),
                    ]),
                ],
            },] },
];
/**
 * @nocollapse
 */
MdExpansionPanel.ctorParameters = function () { return [
    { type: MdAccordion, decorators: [{ type: Optional }, { type: Host },] },
    { type: ChangeDetectorRef, },
    { type: UniqueSelectionDispatcher, },
]; };
MdExpansionPanel.propDecorators = {
    'hideToggle': [{ type: Input },],
};
var MdExpansionPanelActionRow = (function () {
    function MdExpansionPanelActionRow() {
    }
    return MdExpansionPanelActionRow;
}());
MdExpansionPanelActionRow.decorators = [
    { type: Directive, args: [{
                selector: 'mat-action-row, md-action-row',
                host: {
                    class: 'mat-action-row'
                }
            },] },
];
/**
 * @nocollapse
 */
MdExpansionPanelActionRow.ctorParameters = function () { return []; };
/**
 * <md-expansion-panel-header> component.
 *
 * This component corresponds to the header element of an <md-expansion-panel>.
 *
 * Please refer to README.md for examples on how to use it.
 */
var MdExpansionPanelHeader = (function () {
    /**
     * @param {?} renderer
     * @param {?} panel
     * @param {?} _element
     * @param {?} _focusMonitor
     * @param {?} _changeDetectorRef
     */
    function MdExpansionPanelHeader(renderer, panel, _element, _focusMonitor, _changeDetectorRef) {
        var _this = this;
        this.panel = panel;
        this._element = _element;
        this._focusMonitor = _focusMonitor;
        this._changeDetectorRef = _changeDetectorRef;
        this._parentChangeSubscription = Subscription.EMPTY;
        // Since the toggle state depends on an @Input on the panel, we
        // need to  subscribe and trigger change detection manually.
        this._parentChangeSubscription = merge(panel.opened, panel.closed, filter.call(panel._inputChanges, function (changes) { return !!(changes.hideToggle || changes.disabled); }))
            .subscribe(function () { return _this._changeDetectorRef.markForCheck(); });
        _focusMonitor.monitor(_element.nativeElement, renderer, false);
    }
    /**
     * Toggles the expanded state of the panel.
     * @return {?}
     */
    MdExpansionPanelHeader.prototype._toggle = function () {
        if (!this.panel.disabled) {
            this.panel.toggle();
        }
    };
    /**
     * Gets whether the panel is expanded.
     * @return {?}
     */
    MdExpansionPanelHeader.prototype._isExpanded = function () {
        return this.panel.expanded;
    };
    /**
     * Gets the expanded state string of the panel.
     * @return {?}
     */
    MdExpansionPanelHeader.prototype._getExpandedState = function () {
        return this.panel._getExpandedState();
    };
    /**
     * Gets the panel id.
     * @return {?}
     */
    MdExpansionPanelHeader.prototype._getPanelId = function () {
        return this.panel.id;
    };
    /**
     * Gets whether the expand indicator should be shown.
     * @return {?}
     */
    MdExpansionPanelHeader.prototype._showToggle = function () {
        return !this.panel.hideToggle && !this.panel.disabled;
    };
    /**
     * Handle keyup event calling to toggle() if appropriate.
     * @param {?} event
     * @return {?}
     */
    MdExpansionPanelHeader.prototype._keyup = function (event) {
        switch (event.keyCode) {
            // Toggle for space and enter keys.
            case SPACE:
            case ENTER:
                event.preventDefault();
                this._toggle();
                break;
            default:
                return;
        }
    };
    /**
     * @return {?}
     */
    MdExpansionPanelHeader.prototype.ngOnDestroy = function () {
        this._parentChangeSubscription.unsubscribe();
        this._focusMonitor.stopMonitoring(this._element.nativeElement);
    };
    return MdExpansionPanelHeader;
}());
MdExpansionPanelHeader.decorators = [
    { type: Component, args: [{ selector: 'md-expansion-panel-header, mat-expansion-panel-header',
                styles: [".mat-expansion-panel-header{display:flex;flex-direction:row;align-items:center;padding:0 24px}.mat-expansion-panel-header:focus,.mat-expansion-panel-header:hover{outline:0}.mat-expansion-panel-header.mat-expanded:focus,.mat-expansion-panel-header.mat-expanded:hover{background:inherit}.mat-expansion-panel-header:not([aria-disabled=true]){cursor:pointer}.mat-content{display:flex;flex:1;flex-direction:row;overflow:hidden}.mat-expansion-panel-header-description,.mat-expansion-panel-header-title{display:flex;flex-grow:1;margin-right:16px}[dir=rtl] .mat-expansion-panel-header-description,[dir=rtl] .mat-expansion-panel-header-title{margin-right:0;margin-left:16px}.mat-expansion-panel-header-description{flex-grow:2}.mat-expansion-indicator::after{border-style:solid;border-width:0 2px 2px 0;content:'';display:inline-block;padding:3px;transform:rotate(45deg);vertical-align:middle}"],
                template: "<span class=\"mat-content\"><ng-content select=\"md-panel-title, mat-panel-title\"></ng-content><ng-content select=\"md-panel-description, mat-panel-description\"></ng-content><ng-content></ng-content></span><span [@indicatorRotate]=\"_getExpandedState()\" *ngIf=\"_showToggle()\" class=\"mat-expansion-indicator\"></span>",
                encapsulation: ViewEncapsulation.None,
                preserveWhitespaces: false,
                changeDetection: ChangeDetectionStrategy.OnPush,
                host: {
                    'class': 'mat-expansion-panel-header',
                    'role': 'button',
                    '[attr.tabindex]': 'panel.disabled ? -1 : 0',
                    '[attr.aria-controls]': '_getPanelId()',
                    '[attr.aria-expanded]': '_isExpanded()',
                    '[attr.aria-disabled]': 'panel.disabled',
                    '[class.mat-expanded]': '_isExpanded()',
                    '(click)': '_toggle()',
                    '(keyup)': '_keyup($event)',
                    '[@expansionHeight]': "{\n        value: _getExpandedState(),\n        params: {\n          collapsedHeight: collapsedHeight,\n          expandedHeight: expandedHeight\n        }\n    }",
                },
                animations: [
                    trigger('indicatorRotate', [
                        state('collapsed', style({ transform: 'rotate(0deg)' })),
                        state('expanded', style({ transform: 'rotate(180deg)' })),
                        transition('expanded <=> collapsed', animate(EXPANSION_PANEL_ANIMATION_TIMING)),
                    ]),
                    trigger('expansionHeight', [
                        state('collapsed', style({
                            height: '{{collapsedHeight}}',
                        }), {
                            params: { collapsedHeight: '48px' },
                        }),
                        state('expanded', style({
                            height: '{{expandedHeight}}'
                        }), {
                            params: { expandedHeight: '64px' }
                        }),
                        transition('expanded <=> collapsed', animate(EXPANSION_PANEL_ANIMATION_TIMING)),
                    ]),
                ],
            },] },
];
/**
 * @nocollapse
 */
MdExpansionPanelHeader.ctorParameters = function () { return [
    { type: Renderer2, },
    { type: MdExpansionPanel, decorators: [{ type: Host },] },
    { type: ElementRef, },
    { type: FocusMonitor, },
    { type: ChangeDetectorRef, },
]; };
MdExpansionPanelHeader.propDecorators = {
    'expandedHeight': [{ type: Input },],
    'collapsedHeight': [{ type: Input },],
};
/**
 * <md-panel-description> directive.
 *
 * This direction is to be used inside of the MdExpansionPanelHeader component.
 */
var MdExpansionPanelDescription = (function () {
    function MdExpansionPanelDescription() {
    }
    return MdExpansionPanelDescription;
}());
MdExpansionPanelDescription.decorators = [
    { type: Directive, args: [{
                selector: 'md-panel-description, mat-panel-description',
                host: {
                    class: 'mat-expansion-panel-header-description'
                }
            },] },
];
/**
 * @nocollapse
 */
MdExpansionPanelDescription.ctorParameters = function () { return []; };
/**
 * <md-panel-title> directive.
 *
 * This direction is to be used inside of the MdExpansionPanelHeader component.
 */
var MdExpansionPanelTitle = (function () {
    function MdExpansionPanelTitle() {
    }
    return MdExpansionPanelTitle;
}());
MdExpansionPanelTitle.decorators = [
    { type: Directive, args: [{
                selector: 'md-panel-title, mat-panel-title',
                host: {
                    class: 'mat-expansion-panel-header-title'
                }
            },] },
];
/**
 * @nocollapse
 */
MdExpansionPanelTitle.ctorParameters = function () { return []; };
var MdExpansionModule = (function () {
    function MdExpansionModule() {
    }
    return MdExpansionModule;
}());
MdExpansionModule.decorators = [
    { type: NgModule, args: [{
                imports: [CompatibilityModule, CommonModule, A11yModule],
                exports: [
                    CdkAccordion,
                    MdAccordion,
                    MdExpansionPanel,
                    MdExpansionPanelActionRow,
                    MdExpansionPanelHeader,
                    MdExpansionPanelTitle,
                    MdExpansionPanelDescription
                ],
                declarations: [
                    CdkAccordion,
                    MdAccordion,
                    MdExpansionPanel,
                    MdExpansionPanelActionRow,
                    MdExpansionPanelHeader,
                    MdExpansionPanelTitle,
                    MdExpansionPanelDescription
                ],
                providers: [UNIQUE_SELECTION_DISPATCHER_PROVIDER]
            },] },
];
/**
 * @nocollapse
 */
MdExpansionModule.ctorParameters = function () { return []; };
/**
 * Generated bundle index. Do not edit.
 */
export { CdkAccordion, MdAccordion, AccordionItem, MdExpansionPanel, MdExpansionPanelActionRow, MdExpansionPanelHeader, MdExpansionPanelDescription, MdExpansionPanelTitle, MdExpansionModule, MdAccordion as MatAccordion, MdExpansionModule as MatExpansionModule, MdExpansionPanel as MatExpansionPanel, MdExpansionPanelActionRow as MatExpansionPanelActionRow, MdExpansionPanelDescription as MatExpansionPanelDescription, MdExpansionPanelHeader as MatExpansionPanelHeader, MdExpansionPanelTitle as MatExpansionPanelTitle, EXPANSION_PANEL_ANIMATION_TIMING as ɵc14, MdExpansionPanelBase as ɵa14, _MdExpansionPanelMixinBase as ɵb14 };
//# sourceMappingURL=expansion.es5.js.map
