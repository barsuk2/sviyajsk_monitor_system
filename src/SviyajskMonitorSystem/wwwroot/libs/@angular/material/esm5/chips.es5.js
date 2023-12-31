import * as tslib_1 from "tslib";
/**
 * @license
 * Copyright Google Inc. All Rights Reserved.
 *
 * Use of this source code is governed by an MIT-style license that can be
 * found in the LICENSE file at https://angular.io/license
 */
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, ContentChildren, Directive, ElementRef, EventEmitter, Input, NgModule, Optional, Output, Renderer2, Self, ViewEncapsulation } from '@angular/core';
import { FocusKeyManager } from '@angular/cdk/a11y';
import { coerceBooleanProperty } from '@angular/cdk/coercion';
import { SelectionModel } from '@angular/cdk/collections';
import { startWith } from '@angular/cdk/rxjs';
import { FormGroupDirective, NgControl, NgForm } from '@angular/forms';
import { BACKSPACE, DELETE, Directionality, ENTER, LEFT_ARROW, RIGHT_ARROW, SPACE, UP_ARROW, mixinColor, mixinDisabled } from '@angular/material/core';
import { MdFormFieldControl } from '@angular/material/form-field';
import { merge } from 'rxjs/observable/merge';
import { Subject } from 'rxjs/Subject';
import { Subscription } from 'rxjs/Subscription';
/**
 * Event object emitted by MdChip when selected or deselected.
 */
var MdChipSelectionChange = (function () {
    /**
     * @param {?} source
     * @param {?} selected
     * @param {?=} isUserInput
     */
    function MdChipSelectionChange(source, selected, isUserInput) {
        if (isUserInput === void 0) { isUserInput = false; }
        this.source = source;
        this.selected = selected;
        this.isUserInput = isUserInput;
    }
    return MdChipSelectionChange;
}());
/**
 * \@docs-private
 */
var MdChipBase = (function () {
    /**
     * @param {?} _renderer
     * @param {?} _elementRef
     */
    function MdChipBase(_renderer, _elementRef) {
        this._renderer = _renderer;
        this._elementRef = _elementRef;
    }
    return MdChipBase;
}());
var _MdChipMixinBase = mixinColor(mixinDisabled(MdChipBase), 'primary');
/**
 * Dummy directive to add CSS class to basic chips.
 * \@docs-private
 */
var MdBasicChip = (function () {
    function MdBasicChip() {
    }
    return MdBasicChip;
}());
MdBasicChip.decorators = [
    { type: Directive, args: [{
                selector: "md-basic-chip, [md-basic-chip], mat-basic-chip, [mat-basic-chip]",
                host: { 'class': 'mat-basic-chip' }
            },] },
];
/**
 * @nocollapse
 */
MdBasicChip.ctorParameters = function () { return []; };
/**
 * Material design styled Chip component. Used inside the MdChipList component.
 */
var MdChip = (function (_super) {
    tslib_1.__extends(MdChip, _super);
    /**
     * @param {?} renderer
     * @param {?} _elementRef
     */
    function MdChip(renderer, _elementRef) {
        var _this = _super.call(this, renderer, _elementRef) || this;
        _this._elementRef = _elementRef;
        _this._selected = false;
        _this._selectable = true;
        _this._removable = true;
        /**
         * Whether the chip has focus.
         */
        _this._hasFocus = false;
        /**
         * Emits when the chip is focused.
         */
        _this._onFocus = new Subject();
        /**
         * Emits when the chip is blured.
         */
        _this._onBlur = new Subject();
        /**
         * Emitted when the chip is selected or deselected.
         */
        _this.selectionChange = new EventEmitter();
        /**
         * Emitted when the chip is destroyed.
         */
        _this.destroyed = new EventEmitter();
        /**
         * Emitted when the chip is destroyed.
         * @deprecated Use 'destroyed' instead.
         */
        _this.destroy = _this.destroyed;
        /**
         * Emitted when a chip is to be removed.
         */
        _this.removed = new EventEmitter();
        /**
         * Emitted when a chip is to be removed.
         * @deprecated Use `removed` instead.
         */
        _this.onRemove = _this.removed;
        return _this;
    }
    Object.defineProperty(MdChip.prototype, "selected", {
        /**
         * Whether the chip is selected.
         * @return {?}
         */
        get: function () { return this._selected; },
        /**
         * @param {?} value
         * @return {?}
         */
        set: function (value) {
            this._selected = coerceBooleanProperty(value);
            this.selectionChange.emit({
                source: this,
                isUserInput: false,
                selected: value
            });
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdChip.prototype, "value", {
        /**
         * The value of the chip. Defaults to the content inside <md-chip> tags.
         * @return {?}
         */
        get: function () {
            return this._value != undefined
                ? this._value
                : this._elementRef.nativeElement.textContent;
        },
        /**
         * @param {?} newValue
         * @return {?}
         */
        set: function (newValue) { this._value = newValue; },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdChip.prototype, "selectable", {
        /**
         * Whether or not the chips are selectable. When a chip is not selectable,
         * changes to it's selected state are always ignored.
         * @return {?}
         */
        get: function () { return this._selectable; },
        /**
         * @param {?} value
         * @return {?}
         */
        set: function (value) { this._selectable = coerceBooleanProperty(value); },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdChip.prototype, "removable", {
        /**
         * Determines whether or not the chip displays the remove styling and emits (remove) events.
         * @return {?}
         */
        get: function () { return this._removable; },
        /**
         * @param {?} value
         * @return {?}
         */
        set: function (value) { this._removable = coerceBooleanProperty(value); },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdChip.prototype, "ariaSelected", {
        /**
         * @return {?}
         */
        get: function () {
            return this.selectable ? this.selected.toString() : null;
        },
        enumerable: true,
        configurable: true
    });
    /**
     * @return {?}
     */
    MdChip.prototype.ngOnDestroy = function () {
        this.destroyed.emit({ chip: this });
    };
    /**
     * Selects the chip.
     * @return {?}
     */
    MdChip.prototype.select = function () {
        this._selected = true;
        this.selectionChange.emit({
            source: this,
            isUserInput: false,
            selected: true
        });
    };
    /**
     * Deselects the chip.
     * @return {?}
     */
    MdChip.prototype.deselect = function () {
        this._selected = false;
        this.selectionChange.emit({
            source: this,
            isUserInput: false,
            selected: false
        });
    };
    /**
     * Select this chip and emit selected event
     * @return {?}
     */
    MdChip.prototype.selectViaInteraction = function () {
        this._selected = true;
        // Emit select event when selected changes.
        this.selectionChange.emit({
            source: this,
            isUserInput: true,
            selected: true
        });
    };
    /**
     * Toggles the current selected state of this chip.
     * @param {?=} isUserInput
     * @return {?}
     */
    MdChip.prototype.toggleSelected = function (isUserInput) {
        if (isUserInput === void 0) { isUserInput = false; }
        this._selected = !this.selected;
        this.selectionChange.emit({
            source: this,
            isUserInput: isUserInput,
            selected: this._selected
        });
        return this.selected;
    };
    /**
     * Allows for programmatic focusing of the chip.
     * @return {?}
     */
    MdChip.prototype.focus = function () {
        this._elementRef.nativeElement.focus();
        this._onFocus.next({ chip: this });
    };
    /**
     * Allows for programmatic removal of the chip. Called by the MdChipList when the DELETE or
     * BACKSPACE keys are pressed.
     *
     * Informs any listeners of the removal request. Does not remove the chip from the DOM.
     * @return {?}
     */
    MdChip.prototype.remove = function () {
        if (this.removable) {
            this.removed.emit({ chip: this });
        }
    };
    /**
     * Ensures events fire properly upon click.
     * @param {?} event
     * @return {?}
     */
    MdChip.prototype._handleClick = function (event) {
        // Check disabled
        if (this.disabled) {
            return;
        }
        event.preventDefault();
        event.stopPropagation();
        this.focus();
    };
    /**
     * Handle custom key presses.
     * @param {?} event
     * @return {?}
     */
    MdChip.prototype._handleKeydown = function (event) {
        if (this.disabled) {
            return;
        }
        switch (event.keyCode) {
            case DELETE:
            case BACKSPACE:
                // If we are removable, remove the focused chip
                this.remove();
                // Always prevent so page navigation does not occur
                event.preventDefault();
                break;
            case SPACE:
                // If we are selectable, toggle the focused chip
                if (this.selectable) {
                    this.toggleSelected(true);
                }
                // Always prevent space from scrolling the page since the list has focus
                event.preventDefault();
                break;
        }
    };
    /**
     * @return {?}
     */
    MdChip.prototype._blur = function () {
        this._hasFocus = false;
        this._onBlur.next({ chip: this });
    };
    return MdChip;
}(_MdChipMixinBase));
MdChip.decorators = [
    { type: Directive, args: [{
                selector: "md-basic-chip, [md-basic-chip], md-chip, [md-chip],\n             mat-basic-chip, [mat-basic-chip], mat-chip, [mat-chip]",
                inputs: ['color', 'disabled'],
                exportAs: 'mdChip, matChip',
                host: {
                    'class': 'mat-chip',
                    'tabindex': '-1',
                    'role': 'option',
                    '[class.mat-chip-selected]': 'selected',
                    '[attr.disabled]': 'disabled || null',
                    '[attr.aria-disabled]': 'disabled.toString()',
                    '[attr.aria-selected]': 'ariaSelected',
                    '(click)': '_handleClick($event)',
                    '(keydown)': '_handleKeydown($event)',
                    '(focus)': '_hasFocus = true',
                    '(blur)': '_blur()',
                },
            },] },
];
/**
 * @nocollapse
 */
MdChip.ctorParameters = function () { return [
    { type: Renderer2, },
    { type: ElementRef, },
]; };
MdChip.propDecorators = {
    'selected': [{ type: Input },],
    'value': [{ type: Input },],
    'selectable': [{ type: Input },],
    'removable': [{ type: Input },],
    'selectionChange': [{ type: Output },],
    'destroyed': [{ type: Output },],
    'destroy': [{ type: Output },],
    'removed': [{ type: Output },],
    'onRemove': [{ type: Output, args: ['remove',] },],
};
/**
 * Applies proper (click) support and adds styling for use with the Material Design "cancel" icon
 * available at https://material.io/icons/#ic_cancel.
 *
 * Example:
 *
 *     <md-chip>
 *       <md-icon mdChipRemove>cancel</md-icon>
 *     </md-chip>
 *
 * You *may* use a custom icon, but you may need to override the `md-chip-remove` positioning styles
 * to properly center the icon within the chip.
 */
var MdChipRemove = (function () {
    /**
     * @param {?} _parentChip
     */
    function MdChipRemove(_parentChip) {
        this._parentChip = _parentChip;
    }
    /**
     * Calls the parent chip's public `remove()` method if applicable.
     * @return {?}
     */
    MdChipRemove.prototype._handleClick = function () {
        if (this._parentChip.removable) {
            this._parentChip.remove();
        }
    };
    return MdChipRemove;
}());
MdChipRemove.decorators = [
    { type: Directive, args: [{
                selector: '[mdChipRemove], [matChipRemove]',
                host: {
                    'class': 'mat-chip-remove',
                    '(click)': '_handleClick($event)'
                }
            },] },
];
/**
 * @nocollapse
 */
MdChipRemove.ctorParameters = function () { return [
    { type: MdChip, },
]; };
// Increasing integer for generating unique ids for chip-list components.
var nextUniqueId = 0;
/**
 * Change event object that is emitted when the chip list value has changed.
 */
var MdChipListChange = (function () {
    /**
     * @param {?} source
     * @param {?} value
     */
    function MdChipListChange(source, value) {
        this.source = source;
        this.value = value;
    }
    return MdChipListChange;
}());
/**
 * A material design chips component (named ChipList for it's similarity to the List component).
 */
var MdChipList = (function () {
    /**
     * @param {?} _renderer
     * @param {?} _elementRef
     * @param {?} _changeDetectorRef
     * @param {?} _dir
     * @param {?} _parentForm
     * @param {?} _parentFormGroup
     * @param {?} ngControl
     */
    function MdChipList(_renderer, _elementRef, _changeDetectorRef, _dir, _parentForm, _parentFormGroup, ngControl) {
        this._renderer = _renderer;
        this._elementRef = _elementRef;
        this._changeDetectorRef = _changeDetectorRef;
        this._dir = _dir;
        this._parentForm = _parentForm;
        this._parentFormGroup = _parentFormGroup;
        this.ngControl = ngControl;
        /**
         * Stream that emits whenever the state of the input changes such that the wrapping `MdFormField`
         * needs to run change detection.
         */
        this.stateChanges = new Subject();
        /**
         * When a chip is destroyed, we track the index so we can focus the appropriate next chip.
         */
        this._lastDestroyedIndex = null;
        /**
         * Track which chips we're listening to for focus/destruction.
         */
        this._chipSet = new WeakMap();
        /**
         * Subscription to tabbing out from the chip list.
         */
        this._tabOutSubscription = Subscription.EMPTY;
        /**
         * Whether or not the chip is selectable.
         */
        this._selectable = true;
        /**
         * Whether the component is in multiple selection mode.
         */
        this._multiple = false;
        /**
         * Uid of the chip list
         */
        this._uid = "md-chip-list-" + nextUniqueId++;
        /**
         * Whether this is required
         */
        this._required = false;
        /**
         * Whether this is disabled
         */
        this._disabled = false;
        /**
         * Tab index for the chip list.
         */
        this._tabIndex = 0;
        /**
         * User defined tab index.
         * When it is not null, use user defined tab index. Otherwise use _tabIndex
         */
        this._userTabIndex = null;
        /**
         * Function when touched
         */
        this._onTouched = function () { };
        /**
         * Function when changed
         */
        this._onChange = function () { };
        /**
         * Comparison function to specify which option is displayed. Defaults to object equality.
         */
        this._compareWith = function (o1, o2) { return o1 === o2; };
        /**
         * Orientation of the chip list.
         */
        this.ariaOrientation = 'horizontal';
        /**
         * Event emitted when the selected chip list value has been changed by the user.
         */
        this.change = new EventEmitter();
        /**
         * Event that emits whenever the raw value of the chip-list changes. This is here primarily
         * to facilitate the two-way binding for the `value` input.
         * \@docs-private
         */
        this.valueChange = new EventEmitter();
        if (this.ngControl) {
            this.ngControl.valueAccessor = this;
        }
    }
    Object.defineProperty(MdChipList.prototype, "selected", {
        /**
         * The array of selected chips inside chip list.
         * @return {?}
         */
        get: function () {
            return this.multiple ? this._selectionModel.selected : this._selectionModel.selected[0];
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdChipList.prototype, "multiple", {
        /**
         * Whether the user should be allowed to select multiple chips.
         * @return {?}
         */
        get: function () { return this._multiple; },
        /**
         * @param {?} value
         * @return {?}
         */
        set: function (value) {
            this._multiple = coerceBooleanProperty(value);
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdChipList.prototype, "compareWith", {
        /**
         * A function to compare the option values with the selected values. The first argument
         * is a value from an option. The second is a value from the selection. A boolean
         * should be returned.
         * @return {?}
         */
        get: function () { return this._compareWith; },
        /**
         * @param {?} fn
         * @return {?}
         */
        set: function (fn) {
            this._compareWith = fn;
            if (this._selectionModel) {
                // A different comparator means the selection could change.
                this._initializeSelection();
            }
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdChipList.prototype, "value", {
        /**
         * Required for FormFieldControl
         * @return {?}
         */
        get: function () { return this._value; },
        /**
         * @param {?} newValue
         * @return {?}
         */
        set: function (newValue) {
            this.writeValue(newValue);
            this._value = newValue;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdChipList.prototype, "id", {
        /**
         * @return {?}
         */
        get: function () { return this._id || this._uid; },
        /**
         * Required for FormFieldControl. The ID of the chip list
         * @param {?} value
         * @return {?}
         */
        set: function (value) {
            this._id = value;
            this.stateChanges.next();
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdChipList.prototype, "required", {
        /**
         * @return {?}
         */
        get: function () {
            return this._required;
        },
        /**
         * Required for FormFieldControl. Whether the chip list is required.
         * @param {?} value
         * @return {?}
         */
        set: function (value) {
            this._required = coerceBooleanProperty(value);
            this.stateChanges.next();
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdChipList.prototype, "placeholder", {
        /**
         * @return {?}
         */
        get: function () {
            return this._chipInput ? this._chipInput.placeholder : this._placeholder;
        },
        /**
         * For FormFieldControl. Use chip input's placholder if there's a chip input
         * @param {?} value
         * @return {?}
         */
        set: function (value) {
            this._placeholder = value;
            this.stateChanges.next();
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdChipList.prototype, "focused", {
        /**
         * Whether any chips or the mdChipInput inside of this chip-list has focus.
         * @return {?}
         */
        get: function () {
            return this.chips.some(function (chip) { return chip._hasFocus; }) ||
                (this._chipInput && this._chipInput.focused);
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdChipList.prototype, "empty", {
        /**
         * Whether this chip-list contains no chips and no mdChipInput.
         * @return {?}
         */
        get: function () {
            return (!this._chipInput || this._chipInput.empty) && this.chips.length === 0;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdChipList.prototype, "disabled", {
        /**
         * Whether this chip-list is disabled.
         * @return {?}
         */
        get: function () { return this.ngControl ? this.ngControl.disabled : this._disabled; },
        /**
         * @param {?} value
         * @return {?}
         */
        set: function (value) { this._disabled = coerceBooleanProperty(value); },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdChipList.prototype, "errorState", {
        /**
         * Whether the chip list is in an error state.
         * @return {?}
         */
        get: function () {
            var /** @type {?} */ isInvalid = this.ngControl && this.ngControl.invalid;
            var /** @type {?} */ isTouched = this.ngControl && this.ngControl.touched;
            var /** @type {?} */ isSubmitted = (this._parentFormGroup && this._parentFormGroup.submitted) ||
                (this._parentForm && this._parentForm.submitted);
            return !!(isInvalid && (isTouched || isSubmitted));
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdChipList.prototype, "selectable", {
        /**
         * Whether or not this chip is selectable. When a chip is not selectable,
         * its selected state is always ignored.
         * @return {?}
         */
        get: function () { return this._selectable; },
        /**
         * @param {?} value
         * @return {?}
         */
        set: function (value) { this._selectable = coerceBooleanProperty(value); },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdChipList.prototype, "tabIndex", {
        /**
         * @param {?} value
         * @return {?}
         */
        set: function (value) {
            this._userTabIndex = value;
            this._tabIndex = value;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdChipList.prototype, "chipSelectionChanges", {
        /**
         * Combined stream of all of the child chips' selection change events.
         * @return {?}
         */
        get: function () {
            return merge.apply(void 0, this.chips.map(function (chip) { return chip.selectionChange; }));
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdChipList.prototype, "chipFocusChanges", {
        /**
         * Combined stream of all of the child chips' focus change events.
         * @return {?}
         */
        get: function () {
            return merge.apply(void 0, this.chips.map(function (chip) { return chip._onFocus; }));
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdChipList.prototype, "chipBlurChanges", {
        /**
         * Combined stream of all of the child chips' blur change events.
         * @return {?}
         */
        get: function () {
            return merge.apply(void 0, this.chips.map(function (chip) { return chip._onBlur; }));
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdChipList.prototype, "chipRemoveChanges", {
        /**
         * Combined stream of all of the child chips' remove change events.
         * @return {?}
         */
        get: function () {
            return merge.apply(void 0, this.chips.map(function (chip) { return chip.destroy; }));
        },
        enumerable: true,
        configurable: true
    });
    /**
     * @return {?}
     */
    MdChipList.prototype.ngAfterContentInit = function () {
        var _this = this;
        this._keyManager = new FocusKeyManager(this.chips).withWrap();
        // Prevents the chip list from capturing focus and redirecting
        // it back to the first chip when the user tabs out.
        this._tabOutSubscription = this._keyManager.tabOut.subscribe(function () {
            _this._tabIndex = -1;
            setTimeout(function () { return _this._tabIndex = _this._userTabIndex || 0; });
        });
        // When the list changes, re-subscribe
        this._changeSubscription = startWith.call(this.chips.changes, null).subscribe(function () {
            _this._resetChips();
            // Reset chips selected/deselected status
            _this._initializeSelection();
            // Check to see if we need to update our tab index
            _this._updateTabIndex();
            // Check to see if we have a destroyed chip and need to refocus
            _this._updateFocusForDestroyedChips();
        });
    };
    /**
     * @return {?}
     */
    MdChipList.prototype.ngOnInit = function () {
        this._selectionModel = new SelectionModel(this.multiple, undefined, false);
        this.stateChanges.next();
    };
    /**
     * @return {?}
     */
    MdChipList.prototype.ngOnDestroy = function () {
        this._tabOutSubscription.unsubscribe();
        if (this._changeSubscription) {
            this._changeSubscription.unsubscribe();
        }
        this._dropSubscriptions();
    };
    /**
     * Associates an HTML input element with this chip list.
     * @param {?} inputElement
     * @return {?}
     */
    MdChipList.prototype.registerInput = function (inputElement) {
        this._chipInput = inputElement;
    };
    /**
     * @param {?} ids
     * @return {?}
     */
    MdChipList.prototype.setDescribedByIds = function (ids) { this._ariaDescribedby = ids.join(' '); };
    /**
     * @param {?} value
     * @return {?}
     */
    MdChipList.prototype.writeValue = function (value) {
        if (this.chips) {
            this._setSelectionByValue(value, false);
        }
    };
    /**
     * @param {?} fn
     * @return {?}
     */
    MdChipList.prototype.registerOnChange = function (fn) {
        this._onChange = fn;
    };
    /**
     * @param {?} fn
     * @return {?}
     */
    MdChipList.prototype.registerOnTouched = function (fn) {
        this._onTouched = fn;
    };
    /**
     * @param {?} disabled
     * @return {?}
     */
    MdChipList.prototype.setDisabledState = function (disabled) {
        this.disabled = disabled;
        this._renderer.setProperty(this._elementRef.nativeElement, 'disabled', disabled);
        this.stateChanges.next();
    };
    /**
     * Focuses the the first non-disabled chip in this chip list, or the associated input when there
     * are no eligible chips.
     * @return {?}
     */
    MdChipList.prototype.focus = function () {
        // TODO: ARIA says this should focus the first `selected` chip if any are selected.
        // Focus on first element if there's no chipInput inside chip-list
        if (this._chipInput && this._chipInput.focused) {
            // do nothing
        }
        else if (this.chips.length > 0) {
            this._keyManager.setFirstItemActive();
            this.stateChanges.next();
        }
        else {
            this._focusInput();
            this.stateChanges.next();
        }
    };
    /**
     * Attempt to focus an input if we have one.
     * @return {?}
     */
    MdChipList.prototype._focusInput = function () {
        if (this._chipInput) {
            this._chipInput.focus();
        }
    };
    /**
     * Pass events to the keyboard manager. Available here for tests.
     * @param {?} event
     * @return {?}
     */
    MdChipList.prototype._keydown = function (event) {
        var /** @type {?} */ code = event.keyCode;
        var /** @type {?} */ target = (event.target);
        var /** @type {?} */ isInputEmpty = this._isInputEmpty(target);
        var /** @type {?} */ isRtl = this._dir && this._dir.value == 'rtl';
        var /** @type {?} */ isPrevKey = (code === (isRtl ? RIGHT_ARROW : LEFT_ARROW));
        var /** @type {?} */ isNextKey = (code === (isRtl ? LEFT_ARROW : RIGHT_ARROW));
        var /** @type {?} */ isBackKey = (code === BACKSPACE || code == DELETE || code == UP_ARROW || isPrevKey);
        // If they are on an empty input and hit backspace/delete/left arrow, focus the last chip
        if (isInputEmpty && isBackKey) {
            this._keyManager.setLastItemActive();
            event.preventDefault();
            return;
        }
        // If they are on a chip, check for space/left/right, otherwise pass to our key manager (like
        // up/down keys)
        if (target && target.classList.contains('mat-chip')) {
            if (isPrevKey) {
                this._keyManager.setPreviousItemActive();
                event.preventDefault();
            }
            else if (isNextKey) {
                this._keyManager.setNextItemActive();
                event.preventDefault();
            }
            else {
                this._keyManager.onKeydown(event);
            }
        }
        this.stateChanges.next();
    };
    /**
     * Check the tab index as you should not be allowed to focus an empty list.
     * @return {?}
     */
    MdChipList.prototype._updateTabIndex = function () {
        // If we have 0 chips, we should not allow keyboard focus
        this._tabIndex = this._userTabIndex || (this.chips.length === 0 ? -1 : 0);
    };
    /**
     * Update key manager's active item when chip is deleted.
     * If the deleted chip is the last chip in chip list, focus the new last chip.
     * Otherwise focus the next chip in the list.
     * Save `_lastDestroyedIndex` so we can set the correct focus.
     * @param {?} chip
     * @return {?}
     */
    MdChipList.prototype._updateKeyManager = function (chip) {
        var /** @type {?} */ chipIndex = this.chips.toArray().indexOf(chip);
        if (this._isValidIndex(chipIndex)) {
            if (chip._hasFocus) {
                // Check whether the chip is not the last item
                if (chipIndex < this.chips.length - 1) {
                    this._keyManager.setActiveItem(chipIndex);
                }
                else if (chipIndex - 1 >= 0) {
                    this._keyManager.setActiveItem(chipIndex - 1);
                }
            }
            if (this._keyManager.activeItemIndex === chipIndex) {
                this._lastDestroyedIndex = chipIndex;
            }
        }
    };
    /**
     * Checks to see if a focus chip was recently destroyed so that we can refocus the next closest
     * one.
     * @return {?}
     */
    MdChipList.prototype._updateFocusForDestroyedChips = function () {
        var /** @type {?} */ chipsArray = this.chips;
        if (this._lastDestroyedIndex != null && chipsArray.length > 0) {
            // Check whether the destroyed chip was the last item
            var /** @type {?} */ newFocusIndex = Math.min(this._lastDestroyedIndex, chipsArray.length - 1);
            this._keyManager.setActiveItem(newFocusIndex);
            var /** @type {?} */ focusChip = this._keyManager.activeItem;
            // Focus the chip
            if (focusChip) {
                focusChip.focus();
            }
        }
        else if (chipsArray.length === 0) {
            this._focusInput();
        }
        // Reset our destroyed index
        this._lastDestroyedIndex = null;
    };
    /**
     * Utility to ensure all indexes are valid.
     *
     * @param {?} index The index to be checked.
     * @return {?} True if the index is valid for our list of chips.
     */
    MdChipList.prototype._isValidIndex = function (index) {
        return index >= 0 && index < this.chips.length;
    };
    /**
     * @param {?} element
     * @return {?}
     */
    MdChipList.prototype._isInputEmpty = function (element) {
        if (element && element.nodeName.toLowerCase() === 'input') {
            var /** @type {?} */ input = (element);
            return !input.value;
        }
        return false;
    };
    /**
     * @param {?} value
     * @param {?=} isUserInput
     * @return {?}
     */
    MdChipList.prototype._setSelectionByValue = function (value, isUserInput) {
        var _this = this;
        if (isUserInput === void 0) { isUserInput = true; }
        this._clearSelection();
        this.chips.forEach(function (chip) { return chip.deselect(); });
        if (Array.isArray(value)) {
            value.forEach(function (currentValue) { return _this._selectValue(currentValue, isUserInput); });
            this._sortValues();
        }
        else {
            var /** @type {?} */ correspondingChip = this._selectValue(value, isUserInput);
            // Shift focus to the active item. Note that we shouldn't do this in multiple
            // mode, because we don't know what chip the user interacted with last.
            if (correspondingChip) {
                this._keyManager.setActiveItem(this.chips.toArray().indexOf(correspondingChip));
            }
        }
    };
    /**
     * Finds and selects the chip based on its value.
     * @param {?} value
     * @param {?=} isUserInput
     * @return {?} Chip that has the corresponding value.
     */
    MdChipList.prototype._selectValue = function (value, isUserInput) {
        var _this = this;
        if (isUserInput === void 0) { isUserInput = true; }
        var /** @type {?} */ correspondingChip = this.chips.find(function (chip) {
            return chip.value != null && _this._compareWith(chip.value, value);
        });
        if (correspondingChip) {
            isUserInput ? correspondingChip.selectViaInteraction() : correspondingChip.select();
            this._selectionModel.select(correspondingChip);
        }
        return correspondingChip;
    };
    /**
     * @return {?}
     */
    MdChipList.prototype._initializeSelection = function () {
        var _this = this;
        // Defer setting the value in order to avoid the "Expression
        // has changed after it was checked" errors from Angular.
        Promise.resolve().then(function () {
            _this._setSelectionByValue(_this.ngControl ? _this.ngControl.value : _this._value, false);
            _this.stateChanges.next();
        });
    };
    /**
     * Deselects every chip in the list.
     * @param {?=} skip Chip that should not be deselected.
     * @return {?}
     */
    MdChipList.prototype._clearSelection = function (skip) {
        this._selectionModel.clear();
        this.chips.forEach(function (chip) {
            if (chip !== skip) {
                chip.deselect();
            }
        });
        this.stateChanges.next();
    };
    /**
     * Sorts the model values, ensuring that they keep the same
     * order that they have in the panel.
     * @return {?}
     */
    MdChipList.prototype._sortValues = function () {
        var _this = this;
        if (this._multiple) {
            this._selectionModel.clear();
            this.chips.forEach(function (chip) {
                if (chip.selected) {
                    _this._selectionModel.select(chip);
                }
            });
            this.stateChanges.next();
        }
    };
    /**
     * Emits change event to set the model value.
     * @param {?=} fallbackValue
     * @return {?}
     */
    MdChipList.prototype._propagateChanges = function (fallbackValue) {
        var /** @type {?} */ valueToEmit = null;
        if (Array.isArray(this.selected)) {
            valueToEmit = this.selected.map(function (chip) { return chip.value; });
        }
        else {
            valueToEmit = this.selected ? this.selected.value : fallbackValue;
        }
        this._value = valueToEmit;
        this.change.emit(new MdChipListChange(this, valueToEmit));
        this.valueChange.emit(valueToEmit);
        this._onChange(valueToEmit);
        this._changeDetectorRef.markForCheck();
    };
    /**
     * When blurred, mark the field as touched when focus moved outside the chip list.
     * @return {?}
     */
    MdChipList.prototype._blur = function () {
        var _this = this;
        if (!this.disabled) {
            if (this._chipInput) {
                // If there's a chip input, we should check whether the focus moved to chip input.
                // If the focus is not moved to chip input, mark the field as touched. If the focus moved
                // to chip input, do nothing.
                // Timeout is needed to wait for the focus() event trigger on chip input.
                setTimeout(function () {
                    if (!_this.focused) {
                        _this._markAsTouched();
                    }
                });
            }
            else {
                // If there's no chip input, then mark the field as touched.
                this._markAsTouched();
            }
        }
    };
    /**
     * Mark the field as touched
     * @return {?}
     */
    MdChipList.prototype._markAsTouched = function () {
        this._onTouched();
        this._changeDetectorRef.markForCheck();
        this.stateChanges.next();
    };
    /**
     * @return {?}
     */
    MdChipList.prototype._resetChips = function () {
        this._dropSubscriptions();
        this._listenToChipsFocus();
        this._listenToChipsSelection();
        this._listenToChipsRemoved();
    };
    /**
     * @return {?}
     */
    MdChipList.prototype._dropSubscriptions = function () {
        if (this._chipFocusSubscription) {
            this._chipFocusSubscription.unsubscribe();
            this._chipFocusSubscription = null;
        }
        if (this._chipBlurSubscription) {
            this._chipBlurSubscription.unsubscribe();
            this._chipBlurSubscription = null;
        }
        if (this._chipSelectionSubscription) {
            this._chipSelectionSubscription.unsubscribe();
            this._chipSelectionSubscription = null;
        }
    };
    /**
     * Listens to user-generated selection events on each chip.
     * @return {?}
     */
    MdChipList.prototype._listenToChipsSelection = function () {
        var _this = this;
        this._chipSelectionSubscription = this.chipSelectionChanges.subscribe(function (event) {
            event.source.selected
                ? _this._selectionModel.select(event.source)
                : _this._selectionModel.deselect(event.source);
            // For single selection chip list, make sure the deselected value is unselected.
            if (!_this.multiple) {
                _this.chips.forEach(function (chip) {
                    if (!_this._selectionModel.isSelected(chip) && chip.selected) {
                        chip.deselect();
                    }
                });
            }
            if (event.isUserInput) {
                _this._propagateChanges();
            }
        });
    };
    /**
     * Listens to user-generated selection events on each chip.
     * @return {?}
     */
    MdChipList.prototype._listenToChipsFocus = function () {
        var _this = this;
        this._chipFocusSubscription = this.chipFocusChanges.subscribe(function (event) {
            var /** @type {?} */ chipIndex = _this.chips.toArray().indexOf(event.chip);
            if (_this._isValidIndex(chipIndex)) {
                _this._keyManager.updateActiveItemIndex(chipIndex);
            }
            _this.stateChanges.next();
        });
        this._chipBlurSubscription = this.chipBlurChanges.subscribe(function (_) {
            _this._blur();
            _this.stateChanges.next();
        });
    };
    /**
     * @return {?}
     */
    MdChipList.prototype._listenToChipsRemoved = function () {
        var _this = this;
        this._chipRemoveSubscription = this.chipRemoveChanges.subscribe(function (event) {
            _this._updateKeyManager(event.chip);
        });
    };
    return MdChipList;
}());
MdChipList.decorators = [
    { type: Component, args: [{ selector: 'md-chip-list, mat-chip-list',
                template: "<div class=\"mat-chip-list-wrapper\"><ng-content></ng-content></div>",
                exportAs: 'mdChipList, matChipList',
                host: {
                    '[attr.tabindex]': '_tabIndex',
                    '[attr.aria-describedby]': '_ariaDescribedby || null',
                    '[attr.aria-required]': 'required.toString()',
                    '[attr.aria-disabled]': 'disabled.toString()',
                    '[attr.aria-invalid]': 'errorState',
                    '[attr.aria-multiselectable]': 'multiple',
                    '[class.mat-chip-list-disabled]': 'disabled',
                    '[class.mat-chip-list-invalid]': 'errorState',
                    '[class.mat-chip-list-required]': 'required',
                    'role': 'listbox',
                    '[attr.aria-orientation]': 'ariaOrientation',
                    'class': 'mat-chip-list',
                    '(focus)': 'focus()',
                    '(blur)': '_blur()',
                    '(keydown)': '_keydown($event)'
                },
                providers: [{ provide: MdFormFieldControl, useExisting: MdChipList }],
                styles: [".mat-chip-list-wrapper{display:flex;flex-direction:row;flex-wrap:wrap;align-items:baseline}.mat-chip:not(.mat-basic-chip){transition:box-shadow 280ms cubic-bezier(.4,0,.2,1);display:inline-flex;padding:7px 12px;border-radius:24px;align-items:center;cursor:default}.mat-chip:not(.mat-basic-chip)+.mat-chip:not(.mat-basic-chip){margin:0 0 3px 8px}[dir=rtl] .mat-chip:not(.mat-basic-chip)+.mat-chip:not(.mat-basic-chip){margin:0 8px 3px 0}.mat-form-field-prefix .mat-chip:not(.mat-basic-chip):last-child{margin-right:8px}[dir=rtl] .mat-form-field-prefix .mat-chip:not(.mat-basic-chip):last-child{margin-left:8px}.mat-chip:not(.mat-basic-chip) .mat-chip-remove.mat-icon{width:1em;height:1em}.mat-chip:not(.mat-basic-chip):focus{box-shadow:0 3px 3px -2px rgba(0,0,0,.2),0 3px 4px 0 rgba(0,0,0,.14),0 1px 8px 0 rgba(0,0,0,.12);outline:0}@media screen and (-ms-high-contrast:active){.mat-chip:not(.mat-basic-chip){outline:solid 1px}}.mat-chip-list-stacked .mat-chip-list-wrapper{display:block}.mat-chip-list-stacked .mat-chip-list-wrapper .mat-chip:not(.mat-basic-chip){display:block;margin:0;margin-bottom:8px}[dir=rtl] .mat-chip-list-stacked .mat-chip-list-wrapper .mat-chip:not(.mat-basic-chip){margin:0;margin-bottom:8px}.mat-chip-list-stacked .mat-chip-list-wrapper .mat-chip:not(.mat-basic-chip):last-child,[dir=rtl] .mat-chip-list-stacked .mat-chip-list-wrapper .mat-chip:not(.mat-basic-chip):last-child{margin-bottom:0}.mat-form-field-prefix .mat-chip-list-wrapper{margin-bottom:8px}.mat-chip-remove{margin-right:-4px;margin-left:6px;cursor:pointer}[dir=rtl] .mat-chip-remove{margin-right:6px;margin-left:-4px}input.mat-chip-input{width:150px;margin:3px}"],
                encapsulation: ViewEncapsulation.None,
                preserveWhitespaces: false,
                changeDetection: ChangeDetectionStrategy.OnPush
            },] },
];
/**
 * @nocollapse
 */
MdChipList.ctorParameters = function () { return [
    { type: Renderer2, },
    { type: ElementRef, },
    { type: ChangeDetectorRef, },
    { type: Directionality, decorators: [{ type: Optional },] },
    { type: NgForm, decorators: [{ type: Optional },] },
    { type: FormGroupDirective, decorators: [{ type: Optional },] },
    { type: NgControl, decorators: [{ type: Optional }, { type: Self },] },
]; };
MdChipList.propDecorators = {
    'multiple': [{ type: Input },],
    'compareWith': [{ type: Input },],
    'value': [{ type: Input },],
    'id': [{ type: Input },],
    'required': [{ type: Input },],
    'placeholder': [{ type: Input },],
    'disabled': [{ type: Input },],
    'ariaOrientation': [{ type: Input, args: ['aria-orientation',] },],
    'selectable': [{ type: Input },],
    'tabIndex': [{ type: Input },],
    'change': [{ type: Output },],
    'valueChange': [{ type: Output },],
    'chips': [{ type: ContentChildren, args: [MdChip,] },],
};
/**
 * Directive that adds chip-specific behaviors to an input element inside <md-form-field>.
 * May be placed inside or outside of an <md-chip-list>.
 */
var MdChipInput = (function () {
    /**
     * @param {?} _elementRef
     */
    function MdChipInput(_elementRef) {
        this._elementRef = _elementRef;
        this.focused = false;
        this._addOnBlur = false;
        /**
         * The list of key codes that will trigger a chipEnd event.
         *
         * Defaults to `[ENTER]`.
         */
        // TODO(tinayuangao): Support Set here
        this.separatorKeyCodes = [ENTER];
        /**
         * Emitted when a chip is to be added.
         */
        this.chipEnd = new EventEmitter();
        this._matChipInputTokenEnd = this.chipEnd;
        this.placeholder = '';
        this._inputElement = this._elementRef.nativeElement;
    }
    Object.defineProperty(MdChipInput.prototype, "chipList", {
        /**
         * Register input for chip list
         * @param {?} value
         * @return {?}
         */
        set: function (value) {
            if (value) {
                this._chipList = value;
                this._chipList.registerInput(this);
            }
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdChipInput.prototype, "addOnBlur", {
        /**
         * Whether or not the chipEnd event will be emitted when the input is blurred.
         * @return {?}
         */
        get: function () { return this._addOnBlur; },
        /**
         * @param {?} value
         * @return {?}
         */
        set: function (value) { this._addOnBlur = coerceBooleanProperty(value); },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdChipInput.prototype, "matChipList", {
        /**
         * @param {?} value
         * @return {?}
         */
        set: function (value) { this.chipList = value; },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdChipInput.prototype, "matAddOnBlur", {
        /**
         * @return {?}
         */
        get: function () { return this._addOnBlur; },
        /**
         * @param {?} value
         * @return {?}
         */
        set: function (value) { this.addOnBlur = value; },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdChipInput.prototype, "matSeparatorKeyCodes", {
        /**
         * @return {?}
         */
        get: function () { return this.separatorKeyCodes; },
        /**
         * @param {?} v
         * @return {?}
         */
        set: function (v) { this.separatorKeyCodes = v; },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdChipInput.prototype, "empty", {
        /**
         * @return {?}
         */
        get: function () {
            var /** @type {?} */ value = this._inputElement.value;
            return value == null || value === '';
        },
        enumerable: true,
        configurable: true
    });
    /**
     * Utility method to make host definition/tests more clear.
     * @param {?=} event
     * @return {?}
     */
    MdChipInput.prototype._keydown = function (event) {
        this._emitChipEnd(event);
    };
    /**
     * Checks to see if the blur should emit the (chipEnd) event.
     * @return {?}
     */
    MdChipInput.prototype._blur = function () {
        if (this.addOnBlur) {
            this._emitChipEnd();
        }
        this.focused = false;
        // Blur the chip list if it is not focused
        if (!this._chipList.focused) {
            this._chipList._blur();
        }
        this._chipList.stateChanges.next();
    };
    /**
     * @return {?}
     */
    MdChipInput.prototype._focus = function () {
        this.focused = true;
        this._chipList.stateChanges.next();
    };
    /**
     * Checks to see if the (chipEnd) event needs to be emitted.
     * @param {?=} event
     * @return {?}
     */
    MdChipInput.prototype._emitChipEnd = function (event) {
        if (!this._inputElement.value && !!event) {
            this._chipList._keydown(event);
        }
        if (!event || this.separatorKeyCodes.indexOf(event.keyCode) > -1) {
            this.chipEnd.emit({ input: this._inputElement, value: this._inputElement.value });
            if (event) {
                event.preventDefault();
            }
        }
    };
    /**
     * @return {?}
     */
    MdChipInput.prototype.focus = function () { this._inputElement.focus(); };
    return MdChipInput;
}());
MdChipInput.decorators = [
    { type: Directive, args: [{
                selector: 'input[mdChipInputFor], input[matChipInputFor]',
                host: {
                    'class': 'mat-chip-input mat-input-element',
                    '(keydown)': '_keydown($event)',
                    '(blur)': '_blur()',
                    '(focus)': '_focus()',
                }
            },] },
];
/**
 * @nocollapse
 */
MdChipInput.ctorParameters = function () { return [
    { type: ElementRef, },
]; };
MdChipInput.propDecorators = {
    'chipList': [{ type: Input, args: ['mdChipInputFor',] },],
    'addOnBlur': [{ type: Input, args: ['mdChipInputAddOnBlur',] },],
    'separatorKeyCodes': [{ type: Input, args: ['mdChipInputSeparatorKeyCodes',] },],
    'chipEnd': [{ type: Output, args: ['mdChipInputTokenEnd',] },],
    '_matChipInputTokenEnd': [{ type: Output, args: ['matChipInputTokenEnd',] },],
    'matChipList': [{ type: Input, args: ['matChipInputFor',] },],
    'matAddOnBlur': [{ type: Input, args: ['matChipInputAddOnBlur',] },],
    'matSeparatorKeyCodes': [{ type: Input, args: ['matChipInputSeparatorKeyCodes',] },],
    'placeholder': [{ type: Input },],
};
var MdChipsModule = (function () {
    function MdChipsModule() {
    }
    return MdChipsModule;
}());
MdChipsModule.decorators = [
    { type: NgModule, args: [{
                imports: [],
                exports: [MdChipList, MdChip, MdChipInput, MdChipRemove, MdChipRemove, MdBasicChip],
                declarations: [MdChipList, MdChip, MdChipInput, MdChipRemove, MdChipRemove, MdBasicChip]
            },] },
];
/**
 * @nocollapse
 */
MdChipsModule.ctorParameters = function () { return []; };
/**
 * Generated bundle index. Do not edit.
 */
export { MdChipsModule, MdChipListChange, MdChipList, MdChipSelectionChange, MdChipBase, _MdChipMixinBase, MdBasicChip, MdChip, MdChipRemove, MdChipInput, MdBasicChip as MatBasicChip, MdChip as MatChip, MdChipBase as MatChipBase, MdChipInput as MatChipInput, MdChipListChange as MatChipListChange, MdChipList as MatChipList, MdChipRemove as MatChipRemove, MdChipsModule as MatChipsModule };
//# sourceMappingURL=chips.es5.js.map
