/**
 * @license
 * Copyright Google Inc. All Rights Reserved.
 *
 * Use of this source code is governed by an MIT-style license that can be
 * found in the LICENSE file at https://angular.io/license
 */
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, ContentChild, ContentChildren, Directive, ElementRef, Inject, Input, NgModule, Optional, ViewChild, ViewEncapsulation } from '@angular/core';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { coerceBooleanProperty } from '@angular/cdk/coercion';
import { first, startWith } from '@angular/cdk/rxjs';
import { MD_PLACEHOLDER_GLOBAL_OPTIONS, PlatformModule } from '@angular/material/core';
import { fromEvent } from 'rxjs/observable/fromEvent';
import { CommonModule } from '@angular/common';

let nextUniqueId = 0;
/**
 * Single error message to be shown underneath the form field.
 */
class MdError {
    constructor() {
        this.id = `mat-error-${nextUniqueId++}`;
    }
}
MdError.decorators = [
    { type: Directive, args: [{
                selector: 'md-error, mat-error',
                host: {
                    'class': 'mat-error',
                    'role': 'alert',
                    '[attr.id]': 'id',
                }
            },] },
];
/**
 * @nocollapse
 */
MdError.ctorParameters = () => [];
MdError.propDecorators = {
    'id': [{ type: Input },],
};

/**
 * An interface which allows a control to work inside of a `MdFormField`.
 * @abstract
 */
class MdFormFieldControl {
    /**
     * Sets the list of element IDs that currently describe this control.
     * @abstract
     * @param {?} ids
     * @return {?}
     */
    setDescribedByIds(ids) { }
    /**
     * Focuses this control.
     * @abstract
     * @return {?}
     */
    focus() { }
}

/**
 * \@docs-private
 * @return {?}
 */
function getMdFormFieldPlaceholderConflictError() {
    return Error('Placeholder attribute and child element were both specified.');
}
/**
 * \@docs-private
 * @param {?} align
 * @return {?}
 */
function getMdFormFieldDuplicatedHintError(align) {
    return Error(`A hint was already declared for 'align="${align}"'.`);
}
/**
 * \@docs-private
 * @return {?}
 */
function getMdFormFieldMissingControlError() {
    return Error('md-form-field must contain a MdFormFieldControl. ' +
        'Did you forget to add mdInput to the native input or textarea element?');
}

let nextUniqueId$2 = 0;
/**
 * Hint text to be shown underneath the form field control.
 */
class MdHint {
    constructor() {
        /**
         * Whether to align the hint label at the start or end of the line.
         */
        this.align = 'start';
        /**
         * Unique ID for the hint. Used for the aria-describedby on the form field control.
         */
        this.id = `mat-hint-${nextUniqueId$2++}`;
    }
}
MdHint.decorators = [
    { type: Directive, args: [{
                selector: 'md-hint, mat-hint',
                host: {
                    'class': 'mat-hint',
                    '[class.mat-right]': 'align == "end"',
                    '[attr.id]': 'id',
                    // Remove align attribute to prevent it from interfering with layout.
                    '[attr.align]': 'null',
                }
            },] },
];
/**
 * @nocollapse
 */
MdHint.ctorParameters = () => [];
MdHint.propDecorators = {
    'align': [{ type: Input },],
    'id': [{ type: Input },],
};

/**
 * The floating placeholder for an `MdFormField`.
 */
class MdPlaceholder {
}
MdPlaceholder.decorators = [
    { type: Directive, args: [{
                selector: 'md-placeholder, mat-placeholder'
            },] },
];
/**
 * @nocollapse
 */
MdPlaceholder.ctorParameters = () => [];

/**
 * Prefix to be placed the the front of the form field.
 */
class MdPrefix {
}
MdPrefix.decorators = [
    { type: Directive, args: [{
                selector: '[mdPrefix], [matPrefix]',
            },] },
];
/**
 * @nocollapse
 */
MdPrefix.ctorParameters = () => [];

/**
 * Suffix to be placed at the end of the form field.
 */
class MdSuffix {
}
MdSuffix.decorators = [
    { type: Directive, args: [{
                selector: '[mdSuffix], [matSuffix]',
            },] },
];
/**
 * @nocollapse
 */
MdSuffix.ctorParameters = () => [];

let nextUniqueId$1 = 0;
/**
 * Container for form controls that applies Material Design styling and behavior.
 */
class MdFormField {
    /**
     * @param {?} _elementRef
     * @param {?} _changeDetectorRef
     * @param {?} placeholderOptions
     */
    constructor(_elementRef, _changeDetectorRef, placeholderOptions) {
        this._elementRef = _elementRef;
        this._changeDetectorRef = _changeDetectorRef;
        /**
         * Color of the form field underline, based on the theme.
         */
        this.color = 'primary';
        /**
         * Override for the logic that disables the placeholder animation in certain cases.
         */
        this._showAlwaysAnimate = false;
        /**
         * State of the md-hint and md-error animations.
         */
        this._subscriptAnimationState = '';
        this._hintLabel = '';
        // Unique id for the hint label.
        this._hintLabelId = `md-hint-${nextUniqueId$1++}`;
        this._placeholderOptions = placeholderOptions ? placeholderOptions : {};
        this.floatPlaceholder = this._placeholderOptions.float || 'auto';
    }
    /**
     * @deprecated Use `color` instead.
     * @return {?}
     */
    get dividerColor() { return this.color; }
    /**
     * @param {?} value
     * @return {?}
     */
    set dividerColor(value) { this.color = value; }
    /**
     * Whether the required marker should be hidden.
     * @return {?}
     */
    get hideRequiredMarker() { return this._hideRequiredMarker; }
    /**
     * @param {?} value
     * @return {?}
     */
    set hideRequiredMarker(value) {
        this._hideRequiredMarker = coerceBooleanProperty(value);
    }
    /**
     * Whether the floating label should always float or not.
     * @return {?}
     */
    get _shouldAlwaysFloat() {
        return this._floatPlaceholder === 'always' && !this._showAlwaysAnimate;
    }
    /**
     * Whether the placeholder can float or not.
     * @return {?}
     */
    get _canPlaceholderFloat() { return this._floatPlaceholder !== 'never'; }
    /**
     * Text for the form field hint.
     * @return {?}
     */
    get hintLabel() { return this._hintLabel; }
    /**
     * @param {?} value
     * @return {?}
     */
    set hintLabel(value) {
        this._hintLabel = value;
        this._processHints();
    }
    /**
     * Whether the placeholder should always float, never float or float as the user types.
     * @return {?}
     */
    get floatPlaceholder() { return this._floatPlaceholder; }
    /**
     * @param {?} value
     * @return {?}
     */
    set floatPlaceholder(value) {
        if (value !== this._floatPlaceholder) {
            this._floatPlaceholder = value || this._placeholderOptions.float || 'auto';
            this._changeDetectorRef.markForCheck();
        }
    }
    /**
     * @return {?}
     */
    ngAfterContentInit() {
        this._validateControlChild();
        // Subscribe to changes in the child control state in order to update the form field UI.
        startWith.call(this._control.stateChanges, null).subscribe(() => {
            this._validatePlaceholders();
            this._syncDescribedByIds();
            this._changeDetectorRef.markForCheck();
        });
        let /** @type {?} */ ngControl = this._control.ngControl;
        if (ngControl && ngControl.valueChanges) {
            ngControl.valueChanges.subscribe(() => {
                this._changeDetectorRef.markForCheck();
            });
        }
        // Re-validate when the number of hints changes.
        startWith.call(this._hintChildren.changes, null).subscribe(() => {
            this._processHints();
            this._changeDetectorRef.markForCheck();
        });
        // Update the aria-described by when the number of errors changes.
        startWith.call(this._errorChildren.changes, null).subscribe(() => {
            this._syncDescribedByIds();
            this._changeDetectorRef.markForCheck();
        });
    }
    /**
     * @return {?}
     */
    ngAfterContentChecked() {
        this._validateControlChild();
    }
    /**
     * @return {?}
     */
    ngAfterViewInit() {
        // Avoid animations on load.
        this._subscriptAnimationState = 'enter';
        this._changeDetectorRef.detectChanges();
    }
    /**
     * Determines whether a class from the NgControl should be forwarded to the host element.
     * @param {?} prop
     * @return {?}
     */
    _shouldForward(prop) {
        let /** @type {?} */ ngControl = this._control ? this._control.ngControl : null;
        return ngControl && ((ngControl))[prop];
    }
    /**
     * Whether the form field has a placeholder.
     * @return {?}
     */
    _hasPlaceholder() {
        return !!(this._control.placeholder || this._placeholderChild);
    }
    /**
     * Determines whether to display hints or errors.
     * @return {?}
     */
    _getDisplayedMessages() {
        return (this._errorChildren && this._errorChildren.length > 0 &&
            this._control.errorState) ? 'error' : 'hint';
    }
    /**
     * Animates the placeholder up and locks it in position.
     * @return {?}
     */
    _animateAndLockPlaceholder() {
        if (this._placeholder && this._canPlaceholderFloat) {
            this._showAlwaysAnimate = true;
            this._floatPlaceholder = 'always';
            first.call(fromEvent(this._placeholder.nativeElement, 'transitionend')).subscribe(() => {
                this._showAlwaysAnimate = false;
            });
            this._changeDetectorRef.markForCheck();
        }
    }
    /**
     * Ensure that there is only one placeholder (either `placeholder` attribute on the child control
     * or child element with the `md-placeholder` directive).
     * @return {?}
     */
    _validatePlaceholders() {
        if (this._control.placeholder && this._placeholderChild) {
            throw getMdFormFieldPlaceholderConflictError();
        }
    }
    /**
     * Does any extra processing that is required when handling the hints.
     * @return {?}
     */
    _processHints() {
        this._validateHints();
        this._syncDescribedByIds();
    }
    /**
     * Ensure that there is a maximum of one of each `<md-hint>` alignment specified, with the
     * attribute being considered as `align="start"`.
     * @return {?}
     */
    _validateHints() {
        if (this._hintChildren) {
            let /** @type {?} */ startHint;
            let /** @type {?} */ endHint;
            this._hintChildren.forEach((hint) => {
                if (hint.align == 'start') {
                    if (startHint || this.hintLabel) {
                        throw getMdFormFieldDuplicatedHintError('start');
                    }
                    startHint = hint;
                }
                else if (hint.align == 'end') {
                    if (endHint) {
                        throw getMdFormFieldDuplicatedHintError('end');
                    }
                    endHint = hint;
                }
            });
        }
    }
    /**
     * Sets the list of element IDs that describe the child control. This allows the control to update
     * its `aria-describedby` attribute accordingly.
     * @return {?}
     */
    _syncDescribedByIds() {
        if (this._control) {
            let /** @type {?} */ ids = [];
            if (this._getDisplayedMessages() === 'hint') {
                let /** @type {?} */ startHint = this._hintChildren ?
                    this._hintChildren.find(hint => hint.align === 'start') : null;
                let /** @type {?} */ endHint = this._hintChildren ?
                    this._hintChildren.find(hint => hint.align === 'end') : null;
                if (startHint) {
                    ids.push(startHint.id);
                }
                else if (this._hintLabel) {
                    ids.push(this._hintLabelId);
                }
                if (endHint) {
                    ids.push(endHint.id);
                }
            }
            else if (this._errorChildren) {
                ids = this._errorChildren.map(mdError => mdError.id);
            }
            this._control.setDescribedByIds(ids);
        }
    }
    /**
     * Throws an error if the form field's control is missing.
     * @return {?}
     */
    _validateControlChild() {
        if (!this._control) {
            throw getMdFormFieldMissingControlError();
        }
    }
}
MdFormField.decorators = [
    { type: Component, args: [{// TODO(mmalerba): the input-container selectors and classes are deprecated and will be removed.
                selector: 'md-input-container, mat-input-container, md-form-field, mat-form-field',
                template: "<div class=\"mat-input-wrapper mat-form-field-wrapper\"><div class=\"mat-input-flex mat-form-field-flex\" #connectionContainer><div class=\"mat-input-prefix mat-form-field-prefix\" *ngIf=\"_prefixChildren.length\"><ng-content select=\"[mdPrefix], [matPrefix]\"></ng-content></div><div class=\"mat-input-infix mat-form-field-infix\"><ng-content></ng-content><span class=\"mat-input-placeholder-wrapper mat-form-field-placeholder-wrapper\"><label class=\"mat-input-placeholder mat-form-field-placeholder\" [attr.for]=\"_control.id\" [attr.aria-owns]=\"_control.id\" [class.mat-empty]=\"_control.empty && !_shouldAlwaysFloat\" [class.mat-form-field-empty]=\"_control.empty && !_shouldAlwaysFloat\" [class.mat-float]=\"_canPlaceholderFloat\" [class.mat-form-field-float]=\"_canPlaceholderFloat\" [class.mat-accent]=\"color == 'accent'\" [class.mat-warn]=\"color == 'warn'\" #placeholder *ngIf=\"_hasPlaceholder()\"><ng-content select=\"md-placeholder, mat-placeholder\"></ng-content>{{_control.placeholder}} <span class=\"mat-placeholder-required mat-form-field-required-marker\" aria-hidden=\"true\" *ngIf=\"!hideRequiredMarker && _control.required\">*</span></label></span></div><div class=\"mat-input-suffix mat-form-field-suffix\" *ngIf=\"_suffixChildren.length\"><ng-content select=\"[mdSuffix], [matSuffix]\"></ng-content></div></div><div class=\"mat-input-underline mat-form-field-underline\" #underline [class.mat-disabled]=\"_control.disabled\"><span class=\"mat-input-ripple mat-form-field-ripple\" [class.mat-accent]=\"color == 'accent'\" [class.mat-warn]=\"color == 'warn'\"></span></div><div class=\"mat-input-subscript-wrapper mat-form-field-subscript-wrapper\" [ngSwitch]=\"_getDisplayedMessages()\"><div *ngSwitchCase=\"'error'\" [@transitionMessages]=\"_subscriptAnimationState\"><ng-content select=\"md-error, mat-error\"></ng-content></div><div class=\"mat-input-hint-wrapper mat-form-field-hint-wrapper\" *ngSwitchCase=\"'hint'\" [@transitionMessages]=\"_subscriptAnimationState\"><div *ngIf=\"hintLabel\" [id]=\"_hintLabelId\" class=\"mat-hint\">{{hintLabel}}</div><ng-content select=\"md-hint:not([align='end']), mat-hint:not([align='end'])\"></ng-content><div class=\"mat-input-hint-spacer mat-form-field-hint-spacer\"></div><ng-content select=\"md-hint[align='end'], mat-hint[align='end']\"></ng-content></div></div></div>",
                // MdInput is a directive and can't have styles, so we need to include its styles here.
                // The MdInput styles are fairly minimal so it shouldn't be a big deal for people who aren't using
                // MdInput.
                styles: [".mat-form-field{display:inline-block;position:relative;text-align:left}[dir=rtl] .mat-form-field{text-align:right}.mat-form-field-wrapper{position:relative}.mat-form-field-flex{display:inline-flex;align-items:baseline;width:100%}.mat-form-field-prefix,.mat-form-field-suffix{white-space:nowrap;flex:none}.mat-form-field-prefix .mat-icon,.mat-form-field-suffix .mat-icon{width:1em}.mat-form-field-prefix .mat-icon-button,.mat-form-field-suffix .mat-icon-button{font:inherit;vertical-align:baseline}.mat-form-field-prefix .mat-icon-button .mat-icon,.mat-form-field-suffix .mat-icon-button .mat-icon{font-size:inherit}.mat-form-field-infix{display:block;position:relative;flex:auto}.mat-form-field-autofill-control:-webkit-autofill+.mat-form-field-placeholder-wrapper .mat-form-field-placeholder{display:none}.mat-form-field-autofill-control:-webkit-autofill+.mat-form-field-placeholder-wrapper .mat-form-field-float{display:block;transition:none}.mat-form-field-placeholder-wrapper{position:absolute;left:0;box-sizing:content-box;width:100%;height:100%;overflow:hidden;pointer-events:none}.mat-form-field-placeholder{position:absolute;left:0;font:inherit;pointer-events:none;width:100%;white-space:nowrap;text-overflow:ellipsis;overflow:hidden;transform:perspective(100px);-ms-transform:none;transform-origin:0 0;transition:transform .4s cubic-bezier(.25,.8,.25,1),color .4s cubic-bezier(.25,.8,.25,1),width .4s cubic-bezier(.25,.8,.25,1);display:none}.mat-focused .mat-form-field-placeholder.mat-form-field-float,.mat-form-field-placeholder.mat-form-field-empty,.mat-form-field-placeholder.mat-form-field-float:not(.mat-form-field-empty){display:block}[dir=rtl] .mat-form-field-placeholder{transform-origin:100% 0;left:auto;right:0}.mat-form-field-placeholder:not(.mat-form-field-empty){transition:none}.mat-form-field-underline{position:absolute;height:1px;width:100%}.mat-form-field-underline.mat-disabled{background-position:0;background-color:transparent}.mat-form-field-underline .mat-form-field-ripple{position:absolute;height:1px;top:0;left:0;width:100%;transform-origin:50%;transform:scaleX(.5);visibility:hidden;transition:background-color .3s cubic-bezier(.55,0,.55,.2)}.mat-focused .mat-form-field-underline .mat-form-field-ripple{height:2px}.mat-focused .mat-form-field-underline .mat-form-field-ripple,.mat-form-field-invalid .mat-form-field-underline .mat-form-field-ripple{visibility:visible;transform:scaleX(1);transition:transform 150ms linear,background-color .3s cubic-bezier(.55,0,.55,.2)}.mat-form-field-subscript-wrapper{position:absolute;width:100%;overflow:hidden}.mat-form-field-placeholder-wrapper .mat-icon,.mat-form-field-subscript-wrapper .mat-icon{width:1em;height:1em;font-size:inherit;vertical-align:baseline}.mat-form-field-hint-wrapper{display:flex}.mat-form-field-hint-spacer{flex:1 0 1em}.mat-error{display:block} .mat-input-element{font:inherit;background:0 0;color:currentColor;border:none;outline:0;padding:0;margin:0;width:100%;max-width:100%;vertical-align:bottom}.mat-input-element:-moz-ui-invalid{box-shadow:none}.mat-input-element::placeholder{color:transparent!important}.mat-input-element::-moz-placeholder{color:transparent!important}.mat-input-element::-webkit-input-placeholder{color:transparent!important}.mat-input-element:-ms-input-placeholder{color:transparent!important}textarea.mat-input-element{resize:vertical;overflow:auto}"],
                animations: [
                    // TODO(mmalerba): Use angular animations for placeholder animation as well.
                    trigger('transitionMessages', [
                        state('enter', style({ opacity: 1, transform: 'translateY(0%)' })),
                        transition('void => enter', [
                            style({ opacity: 0, transform: 'translateY(-100%)' }),
                            animate('300ms cubic-bezier(0.55, 0, 0.55, 0.2)'),
                        ]),
                    ]),
                ],
                host: {
                    'class': 'mat-input-container mat-form-field',
                    '[class.mat-input-invalid]': '_control.errorState',
                    '[class.mat-form-field-invalid]': '_control.errorState',
                    '[class.mat-focused]': '_control.focused',
                    '[class.ng-untouched]': '_shouldForward("untouched")',
                    '[class.ng-touched]': '_shouldForward("touched")',
                    '[class.ng-pristine]': '_shouldForward("pristine")',
                    '[class.ng-dirty]': '_shouldForward("dirty")',
                    '[class.ng-valid]': '_shouldForward("valid")',
                    '[class.ng-invalid]': '_shouldForward("invalid")',
                    '[class.ng-pending]': '_shouldForward("pending")',
                    '(click)': '_control.focus()',
                },
                encapsulation: ViewEncapsulation.None,
                preserveWhitespaces: false,
                changeDetection: ChangeDetectionStrategy.OnPush,
            },] },
];
/**
 * @nocollapse
 */
MdFormField.ctorParameters = () => [
    { type: ElementRef, },
    { type: ChangeDetectorRef, },
    { type: undefined, decorators: [{ type: Optional }, { type: Inject, args: [MD_PLACEHOLDER_GLOBAL_OPTIONS,] },] },
];
MdFormField.propDecorators = {
    'color': [{ type: Input },],
    'dividerColor': [{ type: Input },],
    'hideRequiredMarker': [{ type: Input },],
    'hintLabel': [{ type: Input },],
    'floatPlaceholder': [{ type: Input },],
    'underlineRef': [{ type: ViewChild, args: ['underline',] },],
    '_connectionContainerRef': [{ type: ViewChild, args: ['connectionContainer',] },],
    '_placeholder': [{ type: ViewChild, args: ['placeholder',] },],
    '_control': [{ type: ContentChild, args: [MdFormFieldControl,] },],
    '_placeholderChild': [{ type: ContentChild, args: [MdPlaceholder,] },],
    '_errorChildren': [{ type: ContentChildren, args: [MdError,] },],
    '_hintChildren': [{ type: ContentChildren, args: [MdHint,] },],
    '_prefixChildren': [{ type: ContentChildren, args: [MdPrefix,] },],
    '_suffixChildren': [{ type: ContentChildren, args: [MdSuffix,] },],
};

class MdFormFieldModule {
}
MdFormFieldModule.decorators = [
    { type: NgModule, args: [{
                declarations: [
                    MdError,
                    MdHint,
                    MdFormField,
                    MdPlaceholder,
                    MdPrefix,
                    MdSuffix,
                ],
                imports: [
                    CommonModule,
                    PlatformModule,
                ],
                exports: [
                    MdError,
                    MdHint,
                    MdFormField,
                    MdPlaceholder,
                    MdPrefix,
                    MdSuffix,
                ],
            },] },
];
/**
 * @nocollapse
 */
MdFormFieldModule.ctorParameters = () => [];

/**
 * Generated bundle index. Do not edit.
 */

export { MdFormFieldModule, MdError, MdFormField, MdFormFieldControl, getMdFormFieldPlaceholderConflictError, getMdFormFieldDuplicatedHintError, getMdFormFieldMissingControlError, MdHint, MdPlaceholder, MdPrefix, MdSuffix, MdFormFieldModule as MatFormFieldModule, MdError as MatError, MdFormField as MatFormField, MdFormFieldControl as MatFormFieldControl, MdHint as MatHint, MdPlaceholder as MatPlaceholder, MdPrefix as MatPrefix, MdSuffix as MatSuffix };
//# sourceMappingURL=form-field.js.map
