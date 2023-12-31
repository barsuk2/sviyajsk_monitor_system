/**
 * @license
 * Copyright Google Inc. All Rights Reserved.
 *
 * Use of this source code is governed by an MIT-style license that can be
 * found in the LICENSE file at https://angular.io/license
 */
(function (global, factory) {
	typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports, require('@angular/core'), require('@angular/cdk/coercion'), require('@angular/forms'), require('@angular/cdk/platform'), require('@angular/cdk/a11y'), require('@angular/cdk/bidi'), require('@angular/platform-browser'), require('rxjs/Subject'), require('@angular/cdk/keycodes'), require('@angular/common'), require('@angular/cdk/scrolling'), require('@angular/cdk/overlay'), require('@angular/cdk/portal'), require('@angular/cdk/rxjs'), require('@angular/animations'), require('rxjs/observable/fromEvent')) :
	typeof define === 'function' && define.amd ? define(['exports', '@angular/core', '@angular/cdk/coercion', '@angular/forms', '@angular/cdk/platform', '@angular/cdk/a11y', '@angular/cdk/bidi', '@angular/platform-browser', 'rxjs/Subject', '@angular/cdk/keycodes', '@angular/common', '@angular/cdk/scrolling', '@angular/cdk/overlay', '@angular/cdk/portal', '@angular/cdk/rxjs', '@angular/animations', 'rxjs/observable/fromEvent'], factory) :
	(factory((global.ng = global.ng || {}, global.ng.material = global.ng.material || {}, global.ng.material.input = global.ng.material.input || {}),global.ng.core,global.ng.cdk.coercion,global.ng.forms,global.ng.cdk.platform,global.ng.cdk.a11y,global.ng.cdk.bidi,global.ng.platformBrowser,global.Rx,global.ng.cdk.keycodes,global.ng.common,global.ng.cdk.scrolling,global.ng.cdk.overlay,global.ng.cdk.portal,global.ng.cdk.rxjs,global.ng.animations,global.Rx.Observable));
}(this, (function (exports,_angular_core,_angular_cdk_coercion,_angular_forms,_angular_cdk_platform,_angular_cdk_a11y,_angular_cdk_bidi,_angular_platformBrowser,rxjs_Subject,_angular_cdk_keycodes,_angular_common,_angular_cdk_scrolling,_angular_cdk_overlay,_angular_cdk_portal,_angular_cdk_rxjs,_angular_animations,rxjs_observable_fromEvent) { 'use strict';

/*! *****************************************************************************
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the Apache License, Version 2.0 (the "License"); you may not use
this file except in compliance with the License. You may obtain a copy of the
License at http://www.apache.org/licenses/LICENSE-2.0

THIS CODE IS PROVIDED ON AN *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
MERCHANTABLITY OR NON-INFRINGEMENT.

See the Apache Version 2.0 License for specific language governing permissions
and limitations under the License.
***************************************************************************** */
/* global Reflect, Promise */

var extendStatics = Object.setPrototypeOf ||
    ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
    function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };

function __extends(d, b) {
    extendStatics(d, b);
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
}

/**
 * \@docs-private
 */
var AnimationCurves = (function () {
    function AnimationCurves() {
    }
    return AnimationCurves;
}());
AnimationCurves.STANDARD_CURVE = 'cubic-bezier(0.4,0.0,0.2,1)';
AnimationCurves.DECELERATION_CURVE = 'cubic-bezier(0.0,0.0,0.2,1)';
AnimationCurves.ACCELERATION_CURVE = 'cubic-bezier(0.4,0.0,1,1)';
AnimationCurves.SHARP_CURVE = 'cubic-bezier(0.4,0.0,0.6,1)';
/**
 * \@docs-private
 */
var AnimationDurations = (function () {
    function AnimationDurations() {
    }
    return AnimationDurations;
}());
AnimationDurations.COMPLEX = '375ms';
AnimationDurations.ENTERING = '225ms';
AnimationDurations.EXITING = '195ms';
var MATERIAL_COMPATIBILITY_MODE = new _angular_core.InjectionToken('md-compatibility-mode');
/**
 * Returns an exception to be thrown if the consumer has used
 * an invalid Material prefix on a component.
 * \@docs-private
 * @param {?} prefix
 * @param {?} nodeName
 * @return {?}
 */
function getMdCompatibilityInvalidPrefixError(prefix, nodeName) {
    return Error("The \"" + prefix + "-\" prefix cannot be used in ng-material v1 compatibility mode. " +
        ("It was used on an \"" + nodeName.toLowerCase() + "\" element."));
}
/**
 * Selector that matches all elements that may have style collisions with AngularJS Material.
 */
var MAT_ELEMENTS_SELECTOR = "\n  [mat-button],\n  [mat-fab],\n  [mat-icon-button],\n  [mat-mini-fab],\n  [mat-raised-button],\n  [matCardSubtitle],\n  [matCardTitle],\n  [matCellDef],\n  [matColumnDef],\n  [matDialogActions],\n  [matDialogClose],\n  [matDialogContent],\n  [matDialogTitle],\n  [matHeaderCellDef],\n  [matHeaderRowDef],\n  [matLine],\n  [matRowDef],\n  [matStepLabel],\n  [matStepperNext],\n  [matStepperPrevious],\n  [matTabLabel],\n  [matTabLink],\n  [matTabNav],\n  [matTooltip],\n  [matInput],\n  [matPrefix],\n  [matSuffix],\n  mat-autocomplete,\n  mat-button-toggle,\n  mat-button-toggle,\n  mat-button-toggle-group,\n  mat-card,\n  mat-card-actions,\n  mat-card-content,\n  mat-card-footer,\n  mat-card-header,\n  mat-card-subtitle,\n  mat-card-title,\n  mat-card-title-group,\n  mat-cell,\n  mat-checkbox,\n  mat-chip,\n  mat-dialog-actions,\n  mat-dialog-container,\n  mat-dialog-content,\n  mat-divider,\n  mat-error,\n  mat-grid-list,\n  mat-grid-tile,\n  mat-grid-tile-footer,\n  mat-grid-tile-header,\n  mat-header-cell,\n  mat-header-row,\n  mat-hint,\n  mat-horizontal-stepper,\n  mat-icon,\n  mat-input-container,\n  mat-form-field,\n  mat-list,\n  mat-list-item,\n  mat-menu,\n  mat-nav-list,\n  mat-option,\n  mat-placeholder,\n  mat-progress-bar,\n  mat-pseudo-checkbox,\n  mat-radio-button,\n  mat-radio-group,\n  mat-row,\n  mat-select,\n  mat-sidenav,\n  mat-sidenav-container,\n  mat-slider,\n  mat-spinner,\n  mat-step,\n  mat-tab,\n  mat-table,\n  mat-tab-group,\n  mat-toolbar,\n  mat-vertical-stepper";
/**
 * Selector that matches all elements that may have style collisions with AngularJS Material.
 */
var MD_ELEMENTS_SELECTOR = "\n  [md-button],\n  [md-fab],\n  [md-icon-button],\n  [md-mini-fab],\n  [md-raised-button],\n  [mdCardSubtitle],\n  [mdCardTitle],\n  [mdCellDef],\n  [mdColumnDef],\n  [mdDialogActions],\n  [mdDialogClose],\n  [mdDialogContent],\n  [mdDialogTitle],\n  [mdHeaderCellDef],\n  [mdHeaderRowDef],\n  [mdLine],\n  [mdRowDef],\n  [mdStepLabel],\n  [mdStepperNext],\n  [mdStepperPrevious],\n  [mdTabLabel],\n  [mdTabLink],\n  [mdTabNav],\n  [mdTooltip],\n  [mdInput],\n  [mdPrefix],\n  [mdSuffix],\n  md-autocomplete,\n  md-button-toggle,\n  md-button-toggle,\n  md-button-toggle-group,\n  md-card,\n  md-card-actions,\n  md-card-content,\n  md-card-footer,\n  md-card-header,\n  md-card-subtitle,\n  md-card-title,\n  md-card-title-group,\n  md-cell,\n  md-checkbox,\n  md-chip,\n  md-dialog-actions,\n  md-dialog-container,\n  md-dialog-content,\n  md-divider,\n  md-error,\n  md-grid-list,\n  md-grid-tile,\n  md-grid-tile-footer,\n  md-grid-tile-header,\n  md-header-cell,\n  md-header-row,\n  md-hint,\n  md-horizontal-stepper,\n  md-icon,\n  md-input-container,\n  md-form-field,\n  md-list,\n  md-list-item,\n  md-menu,\n  md-nav-list,\n  md-option,\n  md-placeholder,\n  md-progress-bar,\n  md-pseudo-checkbox,\n  md-radio-button,\n  md-radio-group,\n  md-row,\n  md-select,\n  md-sidenav,\n  md-sidenav-container,\n  md-slider,\n  md-spinner,\n  md-step,\n  md-tab,\n  md-table,\n  md-tab-group,\n  md-toolbar,\n  md-vertical-stepper";
/**
 * Directive that enforces that the `mat-` prefix cannot be used.
 */
var MatPrefixRejector = (function () {
    /**
     * @param {?} isCompatibilityMode
     * @param {?} elementRef
     */
    function MatPrefixRejector(isCompatibilityMode, elementRef) {
        if (!isCompatibilityMode) {
            throw getMdCompatibilityInvalidPrefixError('mat', elementRef.nativeElement.nodeName);
        }
    }
    return MatPrefixRejector;
}());
MatPrefixRejector.decorators = [
    { type: _angular_core.Directive, args: [{ selector: MAT_ELEMENTS_SELECTOR },] },
];
/**
 * @nocollapse
 */
MatPrefixRejector.ctorParameters = function () { return [
    { type: undefined, decorators: [{ type: _angular_core.Optional }, { type: _angular_core.Inject, args: [MATERIAL_COMPATIBILITY_MODE,] },] },
    { type: _angular_core.ElementRef, },
]; };
/**
 * Directive that enforces that the `md-` prefix cannot be used.
 */
var MdPrefixRejector = (function () {
    /**
     * @param {?} isCompatibilityMode
     * @param {?} elementRef
     */
    function MdPrefixRejector(isCompatibilityMode, elementRef) {
        if (isCompatibilityMode) {
            throw getMdCompatibilityInvalidPrefixError('md', elementRef.nativeElement.nodeName);
        }
    }
    return MdPrefixRejector;
}());
MdPrefixRejector.decorators = [
    { type: _angular_core.Directive, args: [{ selector: MD_ELEMENTS_SELECTOR },] },
];
/**
 * @nocollapse
 */
MdPrefixRejector.ctorParameters = function () { return [
    { type: undefined, decorators: [{ type: _angular_core.Optional }, { type: _angular_core.Inject, args: [MATERIAL_COMPATIBILITY_MODE,] },] },
    { type: _angular_core.ElementRef, },
]; };
/**
 * Module that enforces the default compatibility mode settings. When this module is loaded
 * without NoConflictStyleCompatibilityMode also being imported, it will throw an error if
 * there are any uses of the `mat-` prefix.
 */
var CompatibilityModule = (function () {
    function CompatibilityModule() {
    }
    return CompatibilityModule;
}());
CompatibilityModule.decorators = [
    { type: _angular_core.NgModule, args: [{
                declarations: [MatPrefixRejector, MdPrefixRejector],
                exports: [MatPrefixRejector, MdPrefixRejector],
            },] },
];
/**
 * @nocollapse
 */
CompatibilityModule.ctorParameters = function () { return []; };
/**
 * Module that enforces "no-conflict" compatibility mode settings. When this module is loaded,
 * it will throw an error if there are any uses of the `md-` prefix.
 */
var NoConflictStyleCompatibilityMode = (function () {
    function NoConflictStyleCompatibilityMode() {
    }
    return NoConflictStyleCompatibilityMode;
}());
NoConflictStyleCompatibilityMode.decorators = [
    { type: _angular_core.NgModule, args: [{
                providers: [{
                        provide: MATERIAL_COMPATIBILITY_MODE, useValue: true,
                    }],
            },] },
];
/**
 * @nocollapse
 */
NoConflictStyleCompatibilityMode.ctorParameters = function () { return []; };
/**
 * Injection token that configures whether the Material sanity checks are enabled.
 */
var MATERIAL_SANITY_CHECKS = new _angular_core.InjectionToken('md-sanity-checks');
/**
 * Module that captures anything that should be loaded and/or run for *all* Angular Material
 * components. This includes Bidi, compatibility mode, etc.
 *
 * This module should be imported to each top-level component module (e.g., MdTabsModule).
 */
var MdCommonModule = (function () {
    /**
     * @param {?} _document
     * @param {?} _sanityChecksEnabled
     */
    function MdCommonModule(_document, _sanityChecksEnabled) {
        this._document = _document;
        /**
         * Whether we've done the global sanity checks (e.g. a theme is loaded, there is a doctype).
         */
        this._hasDoneGlobalChecks = false;
        if (_sanityChecksEnabled && !this._hasDoneGlobalChecks && _document && _angular_core.isDevMode()) {
            this._checkDoctype();
            this._checkTheme();
            this._hasDoneGlobalChecks = true;
        }
    }
    /**
     * @return {?}
     */
    MdCommonModule.prototype._checkDoctype = function () {
        if (!this._document.doctype) {
            console.warn('Current document does not have a doctype. This may cause ' +
                'some Angular Material components not to behave as expected.');
        }
    };
    /**
     * @return {?}
     */
    MdCommonModule.prototype._checkTheme = function () {
        if (typeof getComputedStyle === 'function') {
            var /** @type {?} */ testElement = this._document.createElement('div');
            testElement.classList.add('mat-theme-loaded-marker');
            this._document.body.appendChild(testElement);
            if (getComputedStyle(testElement).display !== 'none') {
                console.warn('Could not find Angular Material core theme. Most Material ' +
                    'components may not work as expected. For more info refer ' +
                    'to the theming guide: https://material.angular.io/guide/theming');
            }
            this._document.body.removeChild(testElement);
        }
    };
    return MdCommonModule;
}());
MdCommonModule.decorators = [
    { type: _angular_core.NgModule, args: [{
                imports: [CompatibilityModule, _angular_cdk_bidi.BidiModule],
                exports: [CompatibilityModule, _angular_cdk_bidi.BidiModule],
                providers: [{
                        provide: MATERIAL_SANITY_CHECKS, useValue: true,
                    }],
            },] },
];
/**
 * @nocollapse
 */
MdCommonModule.ctorParameters = function () { return [
    { type: undefined, decorators: [{ type: _angular_core.Optional }, { type: _angular_core.Inject, args: [_angular_platformBrowser.DOCUMENT,] },] },
    { type: undefined, decorators: [{ type: _angular_core.Optional }, { type: _angular_core.Inject, args: [MATERIAL_SANITY_CHECKS,] },] },
]; };
/**
 * Mixin to augment a directive with a `disabled` property.
 * @template T
 * @param {?} base
 * @return {?}
 */
function mixinDisabled(base) {
    return (function (_super) {
        __extends(class_1, _super);
        /**
         * @param {...?} args
         */
        function class_1() {
            var args = [];
            for (var _i = 0; _i < arguments.length; _i++) {
                args[_i] = arguments[_i];
            }
            var _this = _super.apply(this, args) || this;
            _this._disabled = false;
            return _this;
        }
        Object.defineProperty(class_1.prototype, "disabled", {
            /**
             * @return {?}
             */
            get: function () { return this._disabled; },
            /**
             * @param {?} value
             * @return {?}
             */
            set: function (value) { this._disabled = _angular_cdk_coercion.coerceBooleanProperty(value); },
            enumerable: true,
            configurable: true
        });
        return class_1;
    }(base));
}
/**
 * Class to coordinate unique selection based on name.
 * Intended to be consumed as an Angular service.
 * This service is needed because native radio change events are only fired on the item currently
 * being selected, and we still need to uncheck the previous selection.
 *
 * This service does not *store* any IDs and names because they may change at any time, so it is
 * less error-prone if they are simply passed through when the events occur.
 */
var UniqueSelectionDispatcher = (function () {
    function UniqueSelectionDispatcher() {
        this._listeners = [];
    }
    /**
     * Notify other items that selection for the given name has been set.
     * @param {?} id ID of the item.
     * @param {?} name Name of the item.
     * @return {?}
     */
    UniqueSelectionDispatcher.prototype.notify = function (id, name) {
        for (var _i = 0, _a = this._listeners; _i < _a.length; _i++) {
            var listener = _a[_i];
            listener(id, name);
        }
    };
    /**
     * Listen for future changes to item selection.
     * @param {?} listener
     * @return {?} Function used to deregister listener
     *
     */
    UniqueSelectionDispatcher.prototype.listen = function (listener) {
        var _this = this;
        this._listeners.push(listener);
        return function () {
            _this._listeners = _this._listeners.filter(function (registered) {
                return listener !== registered;
            });
        };
    };
    return UniqueSelectionDispatcher;
}());
UniqueSelectionDispatcher.decorators = [
    { type: _angular_core.Injectable },
];
/**
 * @nocollapse
 */
UniqueSelectionDispatcher.ctorParameters = function () { return []; };
/**
 * \@docs-private
 * @param {?} parentDispatcher
 * @return {?}
 */
function UNIQUE_SELECTION_DISPATCHER_PROVIDER_FACTORY(parentDispatcher) {
    return parentDispatcher || new UniqueSelectionDispatcher();
}
/**
 * \@docs-private
 */
var UNIQUE_SELECTION_DISPATCHER_PROVIDER = {
    // If there is already a dispatcher available, use that. Otherwise, provide a new one.
    provide: UniqueSelectionDispatcher,
    deps: [[new _angular_core.Optional(), new _angular_core.SkipSelf(), UniqueSelectionDispatcher]],
    useFactory: UNIQUE_SELECTION_DISPATCHER_PROVIDER_FACTORY
};
/**
 * InjectionToken for datepicker that can be used to override default locale code.
 */
var MAT_DATE_LOCALE = new _angular_core.InjectionToken('MAT_DATE_LOCALE');
/**
 * Provider for MAT_DATE_LOCALE injection token.
 */
var MAT_DATE_LOCALE_PROVIDER = { provide: MAT_DATE_LOCALE, useExisting: _angular_core.LOCALE_ID };
/**
 * Adapts type `D` to be usable as a date by cdk-based components that work with dates.
 * @abstract
 */
var DateAdapter = (function () {
    function DateAdapter() {
        this._localeChanges = new rxjs_Subject.Subject();
    }
    Object.defineProperty(DateAdapter.prototype, "localeChanges", {
        /**
         * A stream that emits when the locale changes.
         * @return {?}
         */
        get: function () { return this._localeChanges; },
        enumerable: true,
        configurable: true
    });
    /**
     * Gets the year component of the given date.
     * @abstract
     * @param {?} date The date to extract the year from.
     * @return {?} The year component.
     */
    DateAdapter.prototype.getYear = function (date) { };
    /**
     * Gets the month component of the given date.
     * @abstract
     * @param {?} date The date to extract the month from.
     * @return {?} The month component (0-indexed, 0 = January).
     */
    DateAdapter.prototype.getMonth = function (date) { };
    /**
     * Gets the date of the month component of the given date.
     * @abstract
     * @param {?} date The date to extract the date of the month from.
     * @return {?} The month component (1-indexed, 1 = first of month).
     */
    DateAdapter.prototype.getDate = function (date) { };
    /**
     * Gets the day of the week component of the given date.
     * @abstract
     * @param {?} date The date to extract the day of the week from.
     * @return {?} The month component (0-indexed, 0 = Sunday).
     */
    DateAdapter.prototype.getDayOfWeek = function (date) { };
    /**
     * Gets a list of names for the months.
     * @abstract
     * @param {?} style The naming style (e.g. long = 'January', short = 'Jan', narrow = 'J').
     * @return {?} An ordered list of all month names, starting with January.
     */
    DateAdapter.prototype.getMonthNames = function (style$$1) { };
    /**
     * Gets a list of names for the dates of the month.
     * @abstract
     * @return {?} An ordered list of all date of the month names, starting with '1'.
     */
    DateAdapter.prototype.getDateNames = function () { };
    /**
     * Gets a list of names for the days of the week.
     * @abstract
     * @param {?} style The naming style (e.g. long = 'Sunday', short = 'Sun', narrow = 'S').
     * @return {?} An ordered list of all weekday names, starting with Sunday.
     */
    DateAdapter.prototype.getDayOfWeekNames = function (style$$1) { };
    /**
     * Gets the name for the year of the given date.
     * @abstract
     * @param {?} date The date to get the year name for.
     * @return {?} The name of the given year (e.g. '2017').
     */
    DateAdapter.prototype.getYearName = function (date) { };
    /**
     * Gets the first day of the week.
     * @abstract
     * @return {?} The first day of the week (0-indexed, 0 = Sunday).
     */
    DateAdapter.prototype.getFirstDayOfWeek = function () { };
    /**
     * Gets the number of days in the month of the given date.
     * @abstract
     * @param {?} date The date whose month should be checked.
     * @return {?} The number of days in the month of the given date.
     */
    DateAdapter.prototype.getNumDaysInMonth = function (date) { };
    /**
     * Clones the given date.
     * @abstract
     * @param {?} date The date to clone
     * @return {?} A new date equal to the given date.
     */
    DateAdapter.prototype.clone = function (date) { };
    /**
     * Creates a date with the given year, month, and date. Does not allow over/under-flow of the
     * month and date.
     * @abstract
     * @param {?} year The full year of the date. (e.g. 89 means the year 89, not the year 1989).
     * @param {?} month The month of the date (0-indexed, 0 = January). Must be an integer 0 - 11.
     * @param {?} date The date of month of the date. Must be an integer 1 - length of the given month.
     * @return {?} The new date, or null if invalid.
     */
    DateAdapter.prototype.createDate = function (year, month, date) { };
    /**
     * Gets today's date.
     * @abstract
     * @return {?} Today's date.
     */
    DateAdapter.prototype.today = function () { };
    /**
     * Parses a date from a value.
     * @abstract
     * @param {?} value The value to parse.
     * @param {?} parseFormat The expected format of the value being parsed
     *     (type is implementation-dependent).
     * @return {?} The parsed date.
     */
    DateAdapter.prototype.parse = function (value, parseFormat) { };
    /**
     * Formats a date as a string.
     * @abstract
     * @param {?} date The value to format.
     * @param {?} displayFormat The format to use to display the date as a string.
     * @return {?} The formatted date string.
     */
    DateAdapter.prototype.format = function (date, displayFormat) { };
    /**
     * Adds the given number of years to the date. Years are counted as if flipping 12 pages on the
     * calendar for each year and then finding the closest date in the new month. For example when
     * adding 1 year to Feb 29, 2016, the resulting date will be Feb 28, 2017.
     * @abstract
     * @param {?} date The date to add years to.
     * @param {?} years The number of years to add (may be negative).
     * @return {?} A new date equal to the given one with the specified number of years added.
     */
    DateAdapter.prototype.addCalendarYears = function (date, years) { };
    /**
     * Adds the given number of months to the date. Months are counted as if flipping a page on the
     * calendar for each month and then finding the closest date in the new month. For example when
     * adding 1 month to Jan 31, 2017, the resulting date will be Feb 28, 2017.
     * @abstract
     * @param {?} date The date to add months to.
     * @param {?} months The number of months to add (may be negative).
     * @return {?} A new date equal to the given one with the specified number of months added.
     */
    DateAdapter.prototype.addCalendarMonths = function (date, months) { };
    /**
     * Adds the given number of days to the date. Days are counted as if moving one cell on the
     * calendar for each day.
     * @abstract
     * @param {?} date The date to add days to.
     * @param {?} days The number of days to add (may be negative).
     * @return {?} A new date equal to the given one with the specified number of days added.
     */
    DateAdapter.prototype.addCalendarDays = function (date, days) { };
    /**
     * Gets the RFC 3339 compatible string (https://tools.ietf.org/html/rfc3339) for the given date.
     * @abstract
     * @param {?} date The date to get the ISO date string for.
     * @return {?} The ISO date string date string.
     */
    DateAdapter.prototype.toIso8601 = function (date) { };
    /**
     * Creates a date from an RFC 3339 compatible string (https://tools.ietf.org/html/rfc3339).
     * @abstract
     * @param {?} iso8601String The ISO date string to create a date from
     * @return {?} The date created from the ISO date string.
     */
    DateAdapter.prototype.fromIso8601 = function (iso8601String) { };
    /**
     * Checks whether the given object is considered a date instance by this DateAdapter.
     * @abstract
     * @param {?} obj The object to check
     * @return {?} Whether the object is a date instance.
     */
    DateAdapter.prototype.isDateInstance = function (obj) { };
    /**
     * Checks whether the given date is valid.
     * @abstract
     * @param {?} date The date to check.
     * @return {?} Whether the date is valid.
     */
    DateAdapter.prototype.isValid = function (date) { };
    /**
     * Sets the locale used for all dates.
     * @param {?} locale The new locale.
     * @return {?}
     */
    DateAdapter.prototype.setLocale = function (locale) {
        this.locale = locale;
        this._localeChanges.next();
    };
    /**
     * Compares two dates.
     * @param {?} first The first date to compare.
     * @param {?} second The second date to compare.
     * @return {?} 0 if the dates are equal, a number less than 0 if the first date is earlier,
     *     a number greater than 0 if the first date is later.
     */
    DateAdapter.prototype.compareDate = function (first$$1, second) {
        return this.getYear(first$$1) - this.getYear(second) ||
            this.getMonth(first$$1) - this.getMonth(second) ||
            this.getDate(first$$1) - this.getDate(second);
    };
    /**
     * Checks if two dates are equal.
     * @param {?} first The first date to check.
     * @param {?} second The second date to check.
     *     Null dates are considered equal to other null dates.
     * @return {?}
     */
    DateAdapter.prototype.sameDate = function (first$$1, second) {
        return first$$1 && second ? !this.compareDate(first$$1, second) : first$$1 == second;
    };
    /**
     * Clamp the given date between min and max dates.
     * @param {?} date The date to clamp.
     * @param {?=} min The minimum value to allow. If null or omitted no min is enforced.
     * @param {?=} max The maximum value to allow. If null or omitted no max is enforced.
     * @return {?} `min` if `date` is less than `min`, `max` if date is greater than `max`,
     *     otherwise `date`.
     */
    DateAdapter.prototype.clampDate = function (date, min, max) {
        if (min && this.compareDate(date, min) < 0) {
            return min;
        }
        if (max && this.compareDate(date, max) > 0) {
            return max;
        }
        return date;
    };
    return DateAdapter;
}());
/**
 * Extends an object with the *enumerable* and *own* properties of one or more source objects,
 * similar to Object.assign.
 *
 * @param {?} dest The object which will have properties copied to it.
 * @param {...?} sources The source objects from which properties will be copied.
 * @return {?}
 */
function extendObject(dest) {
    var sources = [];
    for (var _i = 1; _i < arguments.length; _i++) {
        sources[_i - 1] = arguments[_i];
    }
    if (dest == null) {
        throw TypeError('Cannot convert undefined or null to object');
    }
    for (var _a = 0, sources_1 = sources; _a < sources_1.length; _a++) {
        var source = sources_1[_a];
        if (source != null) {
            for (var /** @type {?} */ key in source) {
                if (source.hasOwnProperty(key)) {
                    dest[key] = source[key];
                }
            }
        }
    }
    return dest;
}
/**
 * Whether the browser supports the Intl API.
 */
var SUPPORTS_INTL_API = typeof Intl != 'undefined';
/**
 * The default month names to use if Intl API is not available.
 */
var DEFAULT_MONTH_NAMES = {
    'long': [
        'January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September',
        'October', 'November', 'December'
    ],
    'short': ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
    'narrow': ['J', 'F', 'M', 'A', 'M', 'J', 'J', 'A', 'S', 'O', 'N', 'D']
};
/**
 * The default date names to use if Intl API is not available.
 */
var DEFAULT_DATE_NAMES = range(31, function (i) { return String(i + 1); });
/**
 * The default day of the week names to use if Intl API is not available.
 */
var DEFAULT_DAY_OF_WEEK_NAMES = {
    'long': ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'],
    'short': ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'],
    'narrow': ['S', 'M', 'T', 'W', 'T', 'F', 'S']
};
/**
 * Matches strings that have the form of a valid RFC 3339 string
 * (https://tools.ietf.org/html/rfc3339). Note that the string may not actually be a valid date
 * because the regex will match strings an with out of bounds month, date, etc.
 */
var ISO_8601_REGEX = /^\d{4}-\d{2}-\d{2}(?:T\d{2}:\d{2}:\d{2}(?:\.\d+)?(?:Z|(?:(?:\+|-)\d{2}:\d{2}))?)?$/;
/**
 * Creates an array and fills it with values.
 * @template T
 * @param {?} length
 * @param {?} valueFunction
 * @return {?}
 */
function range(length, valueFunction) {
    var /** @type {?} */ valuesArray = Array(length);
    for (var /** @type {?} */ i = 0; i < length; i++) {
        valuesArray[i] = valueFunction(i);
    }
    return valuesArray;
}
/**
 * Adapts the native JS Date for use with cdk-based components that work with dates.
 */
var NativeDateAdapter = (function (_super) {
    __extends(NativeDateAdapter, _super);
    /**
     * @param {?} matDateLocale
     */
    function NativeDateAdapter(matDateLocale) {
        var _this = _super.call(this) || this;
        /**
         * Whether to use `timeZone: 'utc'` with `Intl.DateTimeFormat` when formatting dates.
         * Without this `Intl.DateTimeFormat` sometimes chooses the wrong timeZone, which can throw off
         * the result. (e.g. in the en-US locale `new Date(1800, 7, 14).toLocaleDateString()`
         * will produce `'8/13/1800'`.
         */
        _this.useUtcForDisplay = true;
        _super.prototype.setLocale.call(_this, matDateLocale);
        return _this;
    }
    /**
     * @param {?} date
     * @return {?}
     */
    NativeDateAdapter.prototype.getYear = function (date) {
        return date.getFullYear();
    };
    /**
     * @param {?} date
     * @return {?}
     */
    NativeDateAdapter.prototype.getMonth = function (date) {
        return date.getMonth();
    };
    /**
     * @param {?} date
     * @return {?}
     */
    NativeDateAdapter.prototype.getDate = function (date) {
        return date.getDate();
    };
    /**
     * @param {?} date
     * @return {?}
     */
    NativeDateAdapter.prototype.getDayOfWeek = function (date) {
        return date.getDay();
    };
    /**
     * @param {?} style
     * @return {?}
     */
    NativeDateAdapter.prototype.getMonthNames = function (style$$1) {
        var _this = this;
        if (SUPPORTS_INTL_API) {
            var /** @type {?} */ dtf_1 = new Intl.DateTimeFormat(this.locale, { month: style$$1 });
            return range(12, function (i) { return _this._stripDirectionalityCharacters(dtf_1.format(new Date(2017, i, 1))); });
        }
        return DEFAULT_MONTH_NAMES[style$$1];
    };
    /**
     * @return {?}
     */
    NativeDateAdapter.prototype.getDateNames = function () {
        var _this = this;
        if (SUPPORTS_INTL_API) {
            var /** @type {?} */ dtf_2 = new Intl.DateTimeFormat(this.locale, { day: 'numeric' });
            return range(31, function (i) { return _this._stripDirectionalityCharacters(dtf_2.format(new Date(2017, 0, i + 1))); });
        }
        return DEFAULT_DATE_NAMES;
    };
    /**
     * @param {?} style
     * @return {?}
     */
    NativeDateAdapter.prototype.getDayOfWeekNames = function (style$$1) {
        var _this = this;
        if (SUPPORTS_INTL_API) {
            var /** @type {?} */ dtf_3 = new Intl.DateTimeFormat(this.locale, { weekday: style$$1 });
            return range(7, function (i) { return _this._stripDirectionalityCharacters(dtf_3.format(new Date(2017, 0, i + 1))); });
        }
        return DEFAULT_DAY_OF_WEEK_NAMES[style$$1];
    };
    /**
     * @param {?} date
     * @return {?}
     */
    NativeDateAdapter.prototype.getYearName = function (date) {
        if (SUPPORTS_INTL_API) {
            var /** @type {?} */ dtf = new Intl.DateTimeFormat(this.locale, { year: 'numeric' });
            return this._stripDirectionalityCharacters(dtf.format(date));
        }
        return String(this.getYear(date));
    };
    /**
     * @return {?}
     */
    NativeDateAdapter.prototype.getFirstDayOfWeek = function () {
        // We can't tell using native JS Date what the first day of the week is, we default to Sunday.
        return 0;
    };
    /**
     * @param {?} date
     * @return {?}
     */
    NativeDateAdapter.prototype.getNumDaysInMonth = function (date) {
        return this.getDate(this._createDateWithOverflow(this.getYear(date), this.getMonth(date) + 1, 0));
    };
    /**
     * @param {?} date
     * @return {?}
     */
    NativeDateAdapter.prototype.clone = function (date) {
        return this.createDate(this.getYear(date), this.getMonth(date), this.getDate(date));
    };
    /**
     * @param {?} year
     * @param {?} month
     * @param {?} date
     * @return {?}
     */
    NativeDateAdapter.prototype.createDate = function (year, month, date) {
        // Check for invalid month and date (except upper bound on date which we have to check after
        // creating the Date).
        if (month < 0 || month > 11) {
            throw Error("Invalid month index \"" + month + "\". Month index has to be between 0 and 11.");
        }
        if (date < 1) {
            throw Error("Invalid date \"" + date + "\". Date has to be greater than 0.");
        }
        var /** @type {?} */ result = this._createDateWithOverflow(year, month, date);
        // Check that the date wasn't above the upper bound for the month, causing the month to overflow
        if (result.getMonth() != month) {
            throw Error("Invalid date \"" + date + "\" for month with index \"" + month + "\".");
        }
        return result;
    };
    /**
     * @return {?}
     */
    NativeDateAdapter.prototype.today = function () {
        return new Date();
    };
    /**
     * @param {?} value
     * @return {?}
     */
    NativeDateAdapter.prototype.parse = function (value) {
        // We have no way using the native JS Date to set the parse format or locale, so we ignore these
        // parameters.
        if (typeof value == 'number') {
            return new Date(value);
        }
        return value ? new Date(Date.parse(value)) : null;
    };
    /**
     * @param {?} date
     * @param {?} displayFormat
     * @return {?}
     */
    NativeDateAdapter.prototype.format = function (date, displayFormat) {
        if (!this.isValid(date)) {
            throw Error('NativeDateAdapter: Cannot format invalid date.');
        }
        if (SUPPORTS_INTL_API) {
            if (this.useUtcForDisplay) {
                date = new Date(Date.UTC(date.getFullYear(), date.getMonth(), date.getDate(), date.getHours(), date.getMinutes(), date.getSeconds(), date.getMilliseconds()));
                displayFormat = extendObject({}, displayFormat, { timeZone: 'utc' });
            }
            var /** @type {?} */ dtf = new Intl.DateTimeFormat(this.locale, displayFormat);
            return this._stripDirectionalityCharacters(dtf.format(date));
        }
        return this._stripDirectionalityCharacters(date.toDateString());
    };
    /**
     * @param {?} date
     * @param {?} years
     * @return {?}
     */
    NativeDateAdapter.prototype.addCalendarYears = function (date, years) {
        return this.addCalendarMonths(date, years * 12);
    };
    /**
     * @param {?} date
     * @param {?} months
     * @return {?}
     */
    NativeDateAdapter.prototype.addCalendarMonths = function (date, months) {
        var /** @type {?} */ newDate = this._createDateWithOverflow(this.getYear(date), this.getMonth(date) + months, this.getDate(date));
        // It's possible to wind up in the wrong month if the original month has more days than the new
        // month. In this case we want to go to the last day of the desired month.
        // Note: the additional + 12 % 12 ensures we end up with a positive number, since JS % doesn't
        // guarantee this.
        if (this.getMonth(newDate) != ((this.getMonth(date) + months) % 12 + 12) % 12) {
            newDate = this._createDateWithOverflow(this.getYear(newDate), this.getMonth(newDate), 0);
        }
        return newDate;
    };
    /**
     * @param {?} date
     * @param {?} days
     * @return {?}
     */
    NativeDateAdapter.prototype.addCalendarDays = function (date, days) {
        return this._createDateWithOverflow(this.getYear(date), this.getMonth(date), this.getDate(date) + days);
    };
    /**
     * @param {?} date
     * @return {?}
     */
    NativeDateAdapter.prototype.toIso8601 = function (date) {
        return [
            date.getUTCFullYear(),
            this._2digit(date.getUTCMonth() + 1),
            this._2digit(date.getUTCDate())
        ].join('-');
    };
    /**
     * @param {?} iso8601String
     * @return {?}
     */
    NativeDateAdapter.prototype.fromIso8601 = function (iso8601String) {
        // The `Date` constructor accepts formats other than ISO 8601, so we need to make sure the
        // string is the right format first.
        if (ISO_8601_REGEX.test(iso8601String)) {
            var /** @type {?} */ d = new Date(iso8601String);
            if (this.isValid(d)) {
                return d;
            }
        }
        return null;
    };
    /**
     * @param {?} obj
     * @return {?}
     */
    NativeDateAdapter.prototype.isDateInstance = function (obj) {
        return obj instanceof Date;
    };
    /**
     * @param {?} date
     * @return {?}
     */
    NativeDateAdapter.prototype.isValid = function (date) {
        return !isNaN(date.getTime());
    };
    /**
     * Creates a date but allows the month and date to overflow.
     * @param {?} year
     * @param {?} month
     * @param {?} date
     * @return {?}
     */
    NativeDateAdapter.prototype._createDateWithOverflow = function (year, month, date) {
        var /** @type {?} */ result = new Date(year, month, date);
        // We need to correct for the fact that JS native Date treats years in range [0, 99] as
        // abbreviations for 19xx.
        if (year >= 0 && year < 100) {
            result.setFullYear(this.getYear(result) - 1900);
        }
        return result;
    };
    /**
     * Pads a number to make it two digits.
     * @param {?} n The number to pad.
     * @return {?} The padded number.
     */
    NativeDateAdapter.prototype._2digit = function (n) {
        return ('00' + n).slice(-2);
    };
    /**
     * Strip out unicode LTR and RTL characters. Edge and IE insert these into formatted dates while
     * other browsers do not. We remove them to make output consistent and because they interfere with
     * date parsing.
     * @param {?} str The string to strip direction characters from.
     * @return {?} The stripped string.
     */
    NativeDateAdapter.prototype._stripDirectionalityCharacters = function (str) {
        return str.replace(/[\u200e\u200f]/g, '');
    };
    return NativeDateAdapter;
}(DateAdapter));
NativeDateAdapter.decorators = [
    { type: _angular_core.Injectable },
];
/**
 * @nocollapse
 */
NativeDateAdapter.ctorParameters = function () { return [
    { type: undefined, decorators: [{ type: _angular_core.Optional }, { type: _angular_core.Inject, args: [MAT_DATE_LOCALE,] },] },
]; };
var MD_DATE_FORMATS = new _angular_core.InjectionToken('md-date-formats');
var MD_NATIVE_DATE_FORMATS = {
    parse: {
        dateInput: null,
    },
    display: {
        dateInput: { year: 'numeric', month: 'numeric', day: 'numeric' },
        monthYearLabel: { year: 'numeric', month: 'short' },
        dateA11yLabel: { year: 'numeric', month: 'long', day: 'numeric' },
        monthYearA11yLabel: { year: 'numeric', month: 'long' },
    }
};
var NativeDateModule = (function () {
    function NativeDateModule() {
    }
    return NativeDateModule;
}());
NativeDateModule.decorators = [
    { type: _angular_core.NgModule, args: [{
                providers: [
                    { provide: DateAdapter, useClass: NativeDateAdapter },
                    MAT_DATE_LOCALE_PROVIDER
                ],
            },] },
];
/**
 * @nocollapse
 */
NativeDateModule.ctorParameters = function () { return []; };
var MdNativeDateModule = (function () {
    function MdNativeDateModule() {
    }
    return MdNativeDateModule;
}());
MdNativeDateModule.decorators = [
    { type: _angular_core.NgModule, args: [{
                imports: [NativeDateModule],
                providers: [{ provide: MD_DATE_FORMATS, useValue: MD_NATIVE_DATE_FORMATS }],
            },] },
];
/**
 * @nocollapse
 */
MdNativeDateModule.ctorParameters = function () { return []; };
/**
 * Injection token that can be used to specify the global error options.
 */
var MD_ERROR_GLOBAL_OPTIONS = new _angular_core.InjectionToken('md-error-global-options');
/**
 * Returns whether control is invalid and is either touched or is a part of a submitted form.
 * @param {?} control
 * @param {?} form
 * @return {?}
 */
function defaultErrorStateMatcher(control, form) {
    var /** @type {?} */ isSubmitted = form && form.submitted;
    return !!(control.invalid && (control.touched || isSubmitted));
}
var GestureConfig = (function (_super) {
    __extends(GestureConfig, _super);
    function GestureConfig() {
        var _this = _super.call(this) || this;
        _this._hammer = typeof window !== 'undefined' ? ((window)).Hammer : null;
        /* List of new event names to add to the gesture support list */
        _this.events = _this._hammer ? [
            'longpress',
            'slide',
            'slidestart',
            'slideend',
            'slideright',
            'slideleft'
        ] : [];
        if (!_this._hammer && _angular_core.isDevMode()) {
            console.warn('Could not find HammerJS. Certain Angular Material ' +
                'components may not work correctly.');
        }
        return _this;
    }
    /**
     * Builds Hammer instance manually to add custom recognizers that match the Material Design spec.
     *
     * Our gesture names come from the Material Design gestures spec:
     * https://www.google.com/design/spec/patterns/gestures.html#gestures-touch-mechanics
     *
     * More information on default recognizers can be found in Hammer docs:
     * http://hammerjs.github.io/recognizer-pan/
     * http://hammerjs.github.io/recognizer-press/
     *
     * @param {?} element Element to which to assign the new HammerJS gestures.
     * @return {?} Newly-created HammerJS instance.
     */
    GestureConfig.prototype.buildHammer = function (element) {
        var /** @type {?} */ mc = new this._hammer(element);
        // Default Hammer Recognizers.
        var /** @type {?} */ pan = new this._hammer.Pan();
        var /** @type {?} */ swipe = new this._hammer.Swipe();
        var /** @type {?} */ press = new this._hammer.Press();
        // Notice that a HammerJS recognizer can only depend on one other recognizer once.
        // Otherwise the previous `recognizeWith` will be dropped.
        // TODO: Confirm threshold numbers with Material Design UX Team
        var /** @type {?} */ slide = this._createRecognizer(pan, { event: 'slide', threshold: 0 }, swipe);
        var /** @type {?} */ longpress = this._createRecognizer(press, { event: 'longpress', time: 500 });
        // Overwrite the default `pan` event to use the swipe event.
        pan.recognizeWith(swipe);
        // Add customized gestures to Hammer manager
        mc.add([swipe, press, pan, slide, longpress]);
        return (mc);
    };
    /**
     * Creates a new recognizer, without affecting the default recognizers of HammerJS
     * @param {?} base
     * @param {?} options
     * @param {...?} inheritances
     * @return {?}
     */
    GestureConfig.prototype._createRecognizer = function (base, options) {
        var inheritances = [];
        for (var _i = 2; _i < arguments.length; _i++) {
            inheritances[_i - 2] = arguments[_i];
        }
        var /** @type {?} */ recognizer = new ((base.constructor))(options);
        inheritances.push(base);
        inheritances.forEach(function (item) { return recognizer.recognizeWith(item); });
        return recognizer;
    };
    return GestureConfig;
}(_angular_platformBrowser.HammerGestureConfig));
GestureConfig.decorators = [
    { type: _angular_core.Injectable },
];
/**
 * @nocollapse
 */
GestureConfig.ctorParameters = function () { return []; };
/**
 * Shared directive to count lines inside a text area, such as a list item.
 * Line elements can be extracted with a \@ContentChildren(MdLine) query, then
 * counted by checking the query list's length.
 */
var MdLine = (function () {
    function MdLine() {
    }
    return MdLine;
}());
MdLine.decorators = [
    { type: _angular_core.Directive, args: [{
                selector: '[md-line], [mat-line], [mdLine], [matLine]',
                host: { 'class': 'mat-line' }
            },] },
];
/**
 * @nocollapse
 */
MdLine.ctorParameters = function () { return []; };
var MdLineModule = (function () {
    function MdLineModule() {
    }
    return MdLineModule;
}());
MdLineModule.decorators = [
    { type: _angular_core.NgModule, args: [{
                imports: [MdCommonModule],
                exports: [MdLine, MdCommonModule],
                declarations: [MdLine],
            },] },
];
/**
 * @nocollapse
 */
MdLineModule.ctorParameters = function () { return []; };
var RippleState = {};
RippleState.FADING_IN = 0;
RippleState.VISIBLE = 1;
RippleState.FADING_OUT = 2;
RippleState.HIDDEN = 3;
RippleState[RippleState.FADING_IN] = "FADING_IN";
RippleState[RippleState.VISIBLE] = "VISIBLE";
RippleState[RippleState.FADING_OUT] = "FADING_OUT";
RippleState[RippleState.HIDDEN] = "HIDDEN";
/**
 * Reference to a previously launched ripple element.
 */
var RippleRef = (function () {
    /**
     * @param {?} _renderer
     * @param {?} element
     * @param {?} config
     */
    function RippleRef(_renderer, element, config) {
        this._renderer = _renderer;
        this.element = element;
        this.config = config;
        /**
         * Current state of the ripple reference.
         */
        this.state = RippleState.HIDDEN;
    }
    /**
     * Fades out the ripple element.
     * @return {?}
     */
    RippleRef.prototype.fadeOut = function () {
        this._renderer.fadeOutRipple(this);
    };
    return RippleRef;
}());
/**
 * Fade-in duration for the ripples. Can be modified with the speedFactor option.
 */
var RIPPLE_FADE_IN_DURATION = 450;
/**
 * Fade-out duration for the ripples in milliseconds. This can't be modified by the speedFactor.
 */
var RIPPLE_FADE_OUT_DURATION = 400;
/**
 * Helper service that performs DOM manipulations. Not intended to be used outside this module.
 * The constructor takes a reference to the ripple directive's host element and a map of DOM
 * event handlers to be installed on the element that triggers ripple animations.
 * This will eventually become a custom renderer once Angular support exists.
 * \@docs-private
 */
var RippleRenderer = (function () {
    /**
     * @param {?} elementRef
     * @param {?} _ngZone
     * @param {?} _ruler
     * @param {?} platform
     */
    function RippleRenderer(elementRef, _ngZone, _ruler, platform) {
        this._ngZone = _ngZone;
        this._ruler = _ruler;
        /**
         * Whether the mouse is currently down or not.
         */
        this._isMousedown = false;
        /**
         * Events to be registered on the trigger element.
         */
        this._triggerEvents = new Map();
        /**
         * Set of currently active ripple references.
         */
        this._activeRipples = new Set();
        /**
         * Ripple config for all ripples created by events.
         */
        this.rippleConfig = {};
        /**
         * Whether mouse ripples should be created or not.
         */
        this.rippleDisabled = false;
        // Only do anything if we're on the browser.
        if (platform.isBrowser) {
            this._containerElement = elementRef.nativeElement;
            // Specify events which need to be registered on the trigger.
            this._triggerEvents.set('mousedown', this.onMousedown.bind(this));
            this._triggerEvents.set('mouseup', this.onMouseup.bind(this));
            this._triggerEvents.set('mouseleave', this.onMouseLeave.bind(this));
            // By default use the host element as trigger element.
            this.setTriggerElement(this._containerElement);
        }
    }
    /**
     * Fades in a ripple at the given coordinates.
     * @param {?} pageX
     * @param {?} pageY
     * @param {?=} config
     * @return {?}
     */
    RippleRenderer.prototype.fadeInRipple = function (pageX, pageY, config) {
        var _this = this;
        if (config === void 0) { config = {}; }
        var /** @type {?} */ containerRect = this._containerElement.getBoundingClientRect();
        if (config.centered) {
            pageX = containerRect.left + containerRect.width / 2;
            pageY = containerRect.top + containerRect.height / 2;
        }
        else {
            // Subtract scroll values from the coordinates because calculations below
            // are always relative to the viewport rectangle.
            var /** @type {?} */ scrollPosition = this._ruler.getViewportScrollPosition();
            pageX -= scrollPosition.left;
            pageY -= scrollPosition.top;
        }
        var /** @type {?} */ radius = config.radius || distanceToFurthestCorner(pageX, pageY, containerRect);
        var /** @type {?} */ duration = RIPPLE_FADE_IN_DURATION * (1 / (config.speedFactor || 1));
        var /** @type {?} */ offsetX = pageX - containerRect.left;
        var /** @type {?} */ offsetY = pageY - containerRect.top;
        var /** @type {?} */ ripple = document.createElement('div');
        ripple.classList.add('mat-ripple-element');
        ripple.style.left = offsetX - radius + "px";
        ripple.style.top = offsetY - radius + "px";
        ripple.style.height = radius * 2 + "px";
        ripple.style.width = radius * 2 + "px";
        // If the color is not set, the default CSS color will be used.
        ripple.style.backgroundColor = config.color || null;
        ripple.style.transitionDuration = duration + "ms";
        this._containerElement.appendChild(ripple);
        // By default the browser does not recalculate the styles of dynamically created
        // ripple elements. This is critical because then the `scale` would not animate properly.
        enforceStyleRecalculation(ripple);
        ripple.style.transform = 'scale(1)';
        // Exposed reference to the ripple that will be returned.
        var /** @type {?} */ rippleRef = new RippleRef(this, ripple, config);
        rippleRef.state = RippleState.FADING_IN;
        // Add the ripple reference to the list of all active ripples.
        this._activeRipples.add(rippleRef);
        // Wait for the ripple element to be completely faded in.
        // Once it's faded in, the ripple can be hidden immediately if the mouse is released.
        this.runTimeoutOutsideZone(function () {
            rippleRef.state = RippleState.VISIBLE;
            if (!config.persistent && !_this._isMousedown) {
                rippleRef.fadeOut();
            }
        }, duration);
        return rippleRef;
    };
    /**
     * Fades out a ripple reference.
     * @param {?} rippleRef
     * @return {?}
     */
    RippleRenderer.prototype.fadeOutRipple = function (rippleRef) {
        // For ripples that are not active anymore, don't re-un the fade-out animation.
        if (!this._activeRipples.delete(rippleRef)) {
            return;
        }
        var /** @type {?} */ rippleEl = rippleRef.element;
        rippleEl.style.transitionDuration = RIPPLE_FADE_OUT_DURATION + "ms";
        rippleEl.style.opacity = '0';
        rippleRef.state = RippleState.FADING_OUT;
        // Once the ripple faded out, the ripple can be safely removed from the DOM.
        this.runTimeoutOutsideZone(function () {
            rippleRef.state = RippleState.HIDDEN; /** @type {?} */
            ((rippleEl.parentNode)).removeChild(rippleEl);
        }, RIPPLE_FADE_OUT_DURATION);
    };
    /**
     * Fades out all currently active ripples.
     * @return {?}
     */
    RippleRenderer.prototype.fadeOutAll = function () {
        this._activeRipples.forEach(function (ripple) { return ripple.fadeOut(); });
    };
    /**
     * Sets the trigger element and registers the mouse events.
     * @param {?} element
     * @return {?}
     */
    RippleRenderer.prototype.setTriggerElement = function (element) {
        var _this = this;
        // Remove all previously register event listeners from the trigger element.
        if (this._triggerElement) {
            this._triggerEvents.forEach(function (fn, type) {
                ((_this._triggerElement)).removeEventListener(type, fn);
            });
        }
        if (element) {
            // If the element is not null, register all event listeners on the trigger element.
            this._ngZone.runOutsideAngular(function () {
                _this._triggerEvents.forEach(function (fn, type) { return element.addEventListener(type, fn); });
            });
        }
        this._triggerElement = element;
    };
    /**
     * Listener being called on mousedown event.
     * @param {?} event
     * @return {?}
     */
    RippleRenderer.prototype.onMousedown = function (event) {
        if (!this.rippleDisabled) {
            this._isMousedown = true;
            this.fadeInRipple(event.pageX, event.pageY, this.rippleConfig);
        }
    };
    /**
     * Listener being called on mouseup event.
     * @return {?}
     */
    RippleRenderer.prototype.onMouseup = function () {
        this._isMousedown = false;
        // Fade-out all ripples that are completely visible and not persistent.
        this._activeRipples.forEach(function (ripple) {
            if (!ripple.config.persistent && ripple.state === RippleState.VISIBLE) {
                ripple.fadeOut();
            }
        });
    };
    /**
     * Listener being called on mouseleave event.
     * @return {?}
     */
    RippleRenderer.prototype.onMouseLeave = function () {
        if (this._isMousedown) {
            this.onMouseup();
        }
    };
    /**
     * Runs a timeout outside of the Angular zone to avoid triggering the change detection.
     * @param {?} fn
     * @param {?=} delay
     * @return {?}
     */
    RippleRenderer.prototype.runTimeoutOutsideZone = function (fn, delay) {
        if (delay === void 0) { delay = 0; }
        this._ngZone.runOutsideAngular(function () { return setTimeout(fn, delay); });
    };
    return RippleRenderer;
}());
/**
 * @param {?} element
 * @return {?}
 */
function enforceStyleRecalculation(element) {
    // Enforce a style recalculation by calling `getComputedStyle` and accessing any property.
    // Calling `getPropertyValue` is important to let optimizers know that this is not a noop.
    // See: https://gist.github.com/paulirish/5d52fb081b3570c81e3a
    window.getComputedStyle(element).getPropertyValue('opacity');
}
/**
 * Returns the distance from the point (x, y) to the furthest corner of a rectangle.
 * @param {?} x
 * @param {?} y
 * @param {?} rect
 * @return {?}
 */
function distanceToFurthestCorner(x, y, rect) {
    var /** @type {?} */ distX = Math.max(Math.abs(x - rect.left), Math.abs(x - rect.right));
    var /** @type {?} */ distY = Math.max(Math.abs(y - rect.top), Math.abs(y - rect.bottom));
    return Math.sqrt(distX * distX + distY * distY);
}
/**
 * Injection token that can be used to specify the global ripple options.
 */
var MD_RIPPLE_GLOBAL_OPTIONS = new _angular_core.InjectionToken('md-ripple-global-options');
var MdRipple = (function () {
    /**
     * @param {?} elementRef
     * @param {?} ngZone
     * @param {?} ruler
     * @param {?} platform
     * @param {?} globalOptions
     */
    function MdRipple(elementRef, ngZone, ruler, platform, globalOptions) {
        /**
         * If set, the radius in pixels of foreground ripples when fully expanded. If unset, the radius
         * will be the distance from the center of the ripple to the furthest corner of the host element's
         * bounding rectangle.
         */
        this.radius = 0;
        /**
         * If set, the normal duration of ripple animations is divided by this value. For example,
         * setting it to 0.5 will cause the animations to take twice as long.
         * A changed speedFactor will not modify the fade-out duration of the ripples.
         */
        this.speedFactor = 1;
        this._rippleRenderer = new RippleRenderer(elementRef, ngZone, ruler, platform);
        this._globalOptions = globalOptions ? globalOptions : {};
        this._updateRippleRenderer();
    }
    Object.defineProperty(MdRipple.prototype, "_matRippleTrigger", {
        /**
         * @return {?}
         */
        get: function () { return this.trigger; },
        /**
         * @param {?} v
         * @return {?}
         */
        set: function (v) { this.trigger = v; },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdRipple.prototype, "_matRippleCentered", {
        /**
         * @return {?}
         */
        get: function () { return this.centered; },
        /**
         * @param {?} v
         * @return {?}
         */
        set: function (v) { this.centered = v; },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdRipple.prototype, "_matRippleDisabled", {
        /**
         * @return {?}
         */
        get: function () { return this.disabled; },
        /**
         * @param {?} v
         * @return {?}
         */
        set: function (v) { this.disabled = v; },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdRipple.prototype, "_matRippleRadius", {
        /**
         * @return {?}
         */
        get: function () { return this.radius; },
        /**
         * @param {?} v
         * @return {?}
         */
        set: function (v) { this.radius = v; },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdRipple.prototype, "_matRippleSpeedFactor", {
        /**
         * @return {?}
         */
        get: function () { return this.speedFactor; },
        /**
         * @param {?} v
         * @return {?}
         */
        set: function (v) { this.speedFactor = v; },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdRipple.prototype, "_matRippleColor", {
        /**
         * @return {?}
         */
        get: function () { return this.color; },
        /**
         * @param {?} v
         * @return {?}
         */
        set: function (v) { this.color = v; },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdRipple.prototype, "_matRippleUnbounded", {
        /**
         * @return {?}
         */
        get: function () { return this.unbounded; },
        /**
         * @param {?} v
         * @return {?}
         */
        set: function (v) { this.unbounded = v; },
        enumerable: true,
        configurable: true
    });
    /**
     * @param {?} changes
     * @return {?}
     */
    MdRipple.prototype.ngOnChanges = function (changes) {
        if ((changes['trigger'] || changes['_matRippleTrigger']) && this.trigger) {
            this._rippleRenderer.setTriggerElement(this.trigger);
        }
        this._updateRippleRenderer();
    };
    /**
     * @return {?}
     */
    MdRipple.prototype.ngOnDestroy = function () {
        // Set the trigger element to null to cleanup all listeners.
        this._rippleRenderer.setTriggerElement(null);
    };
    /**
     * Launches a manual ripple at the specified position.
     * @param {?} pageX
     * @param {?} pageY
     * @param {?=} config
     * @return {?}
     */
    MdRipple.prototype.launch = function (pageX, pageY, config) {
        if (config === void 0) { config = this.rippleConfig; }
        return this._rippleRenderer.fadeInRipple(pageX, pageY, config);
    };
    /**
     * Fades out all currently showing ripple elements.
     * @return {?}
     */
    MdRipple.prototype.fadeOutAll = function () {
        this._rippleRenderer.fadeOutAll();
    };
    Object.defineProperty(MdRipple.prototype, "rippleConfig", {
        /**
         * Ripple configuration from the directive's input values.
         * @return {?}
         */
        get: function () {
            return {
                centered: this.centered,
                speedFactor: this.speedFactor * (this._globalOptions.baseSpeedFactor || 1),
                radius: this.radius,
                color: this.color
            };
        },
        enumerable: true,
        configurable: true
    });
    /**
     * Updates the ripple renderer with the latest ripple configuration.
     * @return {?}
     */
    MdRipple.prototype._updateRippleRenderer = function () {
        this._rippleRenderer.rippleDisabled = this._globalOptions.disabled || this.disabled;
        this._rippleRenderer.rippleConfig = this.rippleConfig;
    };
    return MdRipple;
}());
MdRipple.decorators = [
    { type: _angular_core.Directive, args: [{
                selector: '[md-ripple], [mat-ripple], [mdRipple], [matRipple]',
                exportAs: 'mdRipple, matRipple',
                host: {
                    'class': 'mat-ripple',
                    '[class.mat-ripple-unbounded]': 'unbounded'
                }
            },] },
];
/**
 * @nocollapse
 */
MdRipple.ctorParameters = function () { return [
    { type: _angular_core.ElementRef, },
    { type: _angular_core.NgZone, },
    { type: _angular_cdk_scrolling.ViewportRuler, },
    { type: _angular_cdk_platform.Platform, },
    { type: undefined, decorators: [{ type: _angular_core.Optional }, { type: _angular_core.Inject, args: [MD_RIPPLE_GLOBAL_OPTIONS,] },] },
]; };
MdRipple.propDecorators = {
    'trigger': [{ type: _angular_core.Input, args: ['mdRippleTrigger',] },],
    'centered': [{ type: _angular_core.Input, args: ['mdRippleCentered',] },],
    'disabled': [{ type: _angular_core.Input, args: ['mdRippleDisabled',] },],
    'radius': [{ type: _angular_core.Input, args: ['mdRippleRadius',] },],
    'speedFactor': [{ type: _angular_core.Input, args: ['mdRippleSpeedFactor',] },],
    'color': [{ type: _angular_core.Input, args: ['mdRippleColor',] },],
    'unbounded': [{ type: _angular_core.Input, args: ['mdRippleUnbounded',] },],
    '_matRippleTrigger': [{ type: _angular_core.Input, args: ['matRippleTrigger',] },],
    '_matRippleCentered': [{ type: _angular_core.Input, args: ['matRippleCentered',] },],
    '_matRippleDisabled': [{ type: _angular_core.Input, args: ['matRippleDisabled',] },],
    '_matRippleRadius': [{ type: _angular_core.Input, args: ['matRippleRadius',] },],
    '_matRippleSpeedFactor': [{ type: _angular_core.Input, args: ['matRippleSpeedFactor',] },],
    '_matRippleColor': [{ type: _angular_core.Input, args: ['matRippleColor',] },],
    '_matRippleUnbounded': [{ type: _angular_core.Input, args: ['matRippleUnbounded',] },],
};
var MdRippleModule = (function () {
    function MdRippleModule() {
    }
    return MdRippleModule;
}());
MdRippleModule.decorators = [
    { type: _angular_core.NgModule, args: [{
                imports: [MdCommonModule, _angular_cdk_platform.PlatformModule, _angular_cdk_scrolling.ScrollDispatchModule],
                exports: [MdRipple, MdCommonModule],
                declarations: [MdRipple],
                providers: [_angular_cdk_scrolling.VIEWPORT_RULER_PROVIDER],
            },] },
];
/**
 * @nocollapse
 */
MdRippleModule.ctorParameters = function () { return []; };
/**
 * Component that shows a simplified checkbox without including any kind of "real" checkbox.
 * Meant to be used when the checkbox is purely decorative and a large number of them will be
 * included, such as for the options in a multi-select. Uses no SVGs or complex animations.
 * Note that theming is meant to be handled by the parent element, e.g.
 * `mat-primary .mat-pseudo-checkbox`.
 *
 * Note that this component will be completely invisible to screen-reader users. This is *not*
 * interchangeable with <md-checkbox> and should *not* be used if the user would directly interact
 * with the checkbox. The pseudo-checkbox should only be used as an implementation detail of
 * more complex components that appropriately handle selected / checked state.
 * \@docs-private
 */
var MdPseudoCheckbox = (function () {
    function MdPseudoCheckbox() {
        /**
         * Display state of the checkbox.
         */
        this.state = 'unchecked';
        /**
         * Whether the checkbox is disabled.
         */
        this.disabled = false;
    }
    return MdPseudoCheckbox;
}());
MdPseudoCheckbox.decorators = [
    { type: _angular_core.Component, args: [{ encapsulation: _angular_core.ViewEncapsulation.None,
                preserveWhitespaces: false,
                changeDetection: _angular_core.ChangeDetectionStrategy.OnPush,
                selector: 'md-pseudo-checkbox, mat-pseudo-checkbox',
                styles: [".mat-pseudo-checkbox{width:20px;height:20px;border:2px solid;border-radius:2px;cursor:pointer;display:inline-block;vertical-align:middle;box-sizing:border-box;position:relative;flex-shrink:0;transition:border-color 90ms cubic-bezier(0,0,.2,.1),background-color 90ms cubic-bezier(0,0,.2,.1)}.mat-pseudo-checkbox::after{position:absolute;opacity:0;content:'';border-bottom:2px solid currentColor;transition:opacity 90ms cubic-bezier(0,0,.2,.1)}.mat-pseudo-checkbox.mat-pseudo-checkbox-checked,.mat-pseudo-checkbox.mat-pseudo-checkbox-indeterminate{border:none}.mat-pseudo-checkbox-disabled{cursor:default}.mat-pseudo-checkbox-indeterminate::after{top:9px;left:2px;width:16px;opacity:1}.mat-pseudo-checkbox-checked::after{top:5px;left:3px;width:12px;height:5px;border-left:2px solid currentColor;transform:rotate(-45deg);opacity:1}"],
                template: '',
                host: {
                    'class': 'mat-pseudo-checkbox',
                    '[class.mat-pseudo-checkbox-indeterminate]': 'state === "indeterminate"',
                    '[class.mat-pseudo-checkbox-checked]': 'state === "checked"',
                    '[class.mat-pseudo-checkbox-disabled]': 'disabled',
                },
            },] },
];
/**
 * @nocollapse
 */
MdPseudoCheckbox.ctorParameters = function () { return []; };
MdPseudoCheckbox.propDecorators = {
    'state': [{ type: _angular_core.Input },],
    'disabled': [{ type: _angular_core.Input },],
};
var MdPseudoCheckboxModule = (function () {
    function MdPseudoCheckboxModule() {
    }
    return MdPseudoCheckboxModule;
}());
MdPseudoCheckboxModule.decorators = [
    { type: _angular_core.NgModule, args: [{
                exports: [MdPseudoCheckbox],
                declarations: [MdPseudoCheckbox]
            },] },
];
/**
 * @nocollapse
 */
MdPseudoCheckboxModule.ctorParameters = function () { return []; };
/**
 * \@docs-private
 */
var MdOptgroupBase = (function () {
    function MdOptgroupBase() {
    }
    return MdOptgroupBase;
}());
var _MdOptgroupMixinBase = mixinDisabled(MdOptgroupBase);
// Counter for unique group ids.
var _uniqueOptgroupIdCounter = 0;
/**
 * Component that is used to group instances of `md-option`.
 */
var MdOptgroup = (function (_super) {
    __extends(MdOptgroup, _super);
    function MdOptgroup() {
        var _this = _super.apply(this, arguments) || this;
        /**
         * Unique id for the underlying label.
         */
        _this._labelId = "mat-optgroup-label-" + _uniqueOptgroupIdCounter++;
        return _this;
    }
    return MdOptgroup;
}(_MdOptgroupMixinBase));
MdOptgroup.decorators = [
    { type: _angular_core.Component, args: [{ selector: 'md-optgroup, mat-optgroup',
                template: "<label class=\"mat-optgroup-label\" [id]=\"_labelId\">{{ label }}</label><ng-content select=\"md-option, mat-option\"></ng-content>",
                encapsulation: _angular_core.ViewEncapsulation.None,
                preserveWhitespaces: false,
                changeDetection: _angular_core.ChangeDetectionStrategy.OnPush,
                inputs: ['disabled'],
                host: {
                    'class': 'mat-optgroup',
                    'role': 'group',
                    '[class.mat-optgroup-disabled]': 'disabled',
                    '[attr.aria-disabled]': 'disabled.toString()',
                    '[attr.aria-labelledby]': '_labelId',
                }
            },] },
];
/**
 * @nocollapse
 */
MdOptgroup.ctorParameters = function () { return []; };
MdOptgroup.propDecorators = {
    'label': [{ type: _angular_core.Input },],
};
/**
 * Option IDs need to be unique across components, so this counter exists outside of
 * the component definition.
 */
var _uniqueIdCounter = 0;
/**
 * Event object emitted by MdOption when selected or deselected.
 */
var MdOptionSelectionChange = (function () {
    /**
     * @param {?} source
     * @param {?=} isUserInput
     */
    function MdOptionSelectionChange(source, isUserInput) {
        if (isUserInput === void 0) { isUserInput = false; }
        this.source = source;
        this.isUserInput = isUserInput;
    }
    return MdOptionSelectionChange;
}());
/**
 * Single option inside of a `<md-select>` element.
 */
var MdOption = (function () {
    /**
     * @param {?} _element
     * @param {?} _changeDetectorRef
     * @param {?} group
     */
    function MdOption(_element, _changeDetectorRef, group) {
        this._element = _element;
        this._changeDetectorRef = _changeDetectorRef;
        this.group = group;
        this._selected = false;
        this._active = false;
        this._multiple = false;
        this._disableRipple = false;
        /**
         * Whether the option is disabled.
         */
        this._disabled = false;
        this._id = "md-option-" + _uniqueIdCounter++;
        /**
         * Event emitted when the option is selected or deselected.
         */
        this.onSelectionChange = new _angular_core.EventEmitter();
    }
    Object.defineProperty(MdOption.prototype, "multiple", {
        /**
         * Whether the wrapping component is in multiple selection mode.
         * @return {?}
         */
        get: function () { return this._multiple; },
        /**
         * @param {?} value
         * @return {?}
         */
        set: function (value) {
            if (value !== this._multiple) {
                this._multiple = value;
                this._changeDetectorRef.markForCheck();
            }
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdOption.prototype, "id", {
        /**
         * The unique ID of the option.
         * @return {?}
         */
        get: function () { return this._id; },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdOption.prototype, "selected", {
        /**
         * Whether or not the option is currently selected.
         * @return {?}
         */
        get: function () { return this._selected; },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdOption.prototype, "disabled", {
        /**
         * Whether the option is disabled.
         * @return {?}
         */
        get: function () { return (this.group && this.group.disabled) || this._disabled; },
        /**
         * @param {?} value
         * @return {?}
         */
        set: function (value) { this._disabled = _angular_cdk_coercion.coerceBooleanProperty(value); },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdOption.prototype, "disableRipple", {
        /**
         * Whether ripples for the option are disabled.
         * @return {?}
         */
        get: function () { return this._disableRipple; },
        /**
         * @param {?} value
         * @return {?}
         */
        set: function (value) {
            this._disableRipple = value;
            this._changeDetectorRef.markForCheck();
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdOption.prototype, "active", {
        /**
         * Whether or not the option is currently active and ready to be selected.
         * An active option displays styles as if it is focused, but the
         * focus is actually retained somewhere else. This comes in handy
         * for components like autocomplete where focus must remain on the input.
         * @return {?}
         */
        get: function () {
            return this._active;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdOption.prototype, "viewValue", {
        /**
         * The displayed value of the option. It is necessary to show the selected option in the
         * select's trigger.
         * @return {?}
         */
        get: function () {
            // TODO(kara): Add input property alternative for node envs.
            return (this._getHostElement().textContent || '').trim();
        },
        enumerable: true,
        configurable: true
    });
    /**
     * Selects the option.
     * @return {?}
     */
    MdOption.prototype.select = function () {
        this._selected = true;
        this._changeDetectorRef.markForCheck();
        this._emitSelectionChangeEvent();
    };
    /**
     * Deselects the option.
     * @return {?}
     */
    MdOption.prototype.deselect = function () {
        this._selected = false;
        this._changeDetectorRef.markForCheck();
        this._emitSelectionChangeEvent();
    };
    /**
     * Sets focus onto this option.
     * @return {?}
     */
    MdOption.prototype.focus = function () {
        var /** @type {?} */ element = this._getHostElement();
        if (typeof element.focus === 'function') {
            element.focus();
        }
    };
    /**
     * This method sets display styles on the option to make it appear
     * active. This is used by the ActiveDescendantKeyManager so key
     * events will display the proper options as active on arrow key events.
     * @return {?}
     */
    MdOption.prototype.setActiveStyles = function () {
        if (!this._active) {
            this._active = true;
            this._changeDetectorRef.markForCheck();
        }
    };
    /**
     * This method removes display styles on the option that made it appear
     * active. This is used by the ActiveDescendantKeyManager so key
     * events will display the proper options as active on arrow key events.
     * @return {?}
     */
    MdOption.prototype.setInactiveStyles = function () {
        if (this._active) {
            this._active = false;
            this._changeDetectorRef.markForCheck();
        }
    };
    /**
     * Gets the label to be used when determining whether the option should be focused.
     * @return {?}
     */
    MdOption.prototype.getLabel = function () {
        return this.viewValue;
    };
    /**
     * Ensures the option is selected when activated from the keyboard.
     * @param {?} event
     * @return {?}
     */
    MdOption.prototype._handleKeydown = function (event) {
        if (event.keyCode === _angular_cdk_keycodes.ENTER || event.keyCode === _angular_cdk_keycodes.SPACE) {
            this._selectViaInteraction();
            // Prevent the page from scrolling down and form submits.
            event.preventDefault();
        }
    };
    /**
     * Selects the option while indicating the selection came from the user. Used to
     * determine if the select's view -> model callback should be invoked.
     * @return {?}
     */
    MdOption.prototype._selectViaInteraction = function () {
        if (!this.disabled) {
            this._selected = this.multiple ? !this._selected : true;
            this._changeDetectorRef.markForCheck();
            this._emitSelectionChangeEvent(true);
        }
    };
    /**
     * Returns the correct tabindex for the option depending on disabled state.
     * @return {?}
     */
    MdOption.prototype._getTabIndex = function () {
        return this.disabled ? '-1' : '0';
    };
    /**
     * Gets the host DOM element.
     * @return {?}
     */
    MdOption.prototype._getHostElement = function () {
        return this._element.nativeElement;
    };
    /**
     * Emits the selection change event.
     * @param {?=} isUserInput
     * @return {?}
     */
    MdOption.prototype._emitSelectionChangeEvent = function (isUserInput) {
        if (isUserInput === void 0) { isUserInput = false; }
        this.onSelectionChange.emit(new MdOptionSelectionChange(this, isUserInput));
    };
    /**
     * Counts the amount of option group labels that precede the specified option.
     * @param {?} optionIndex Index of the option at which to start counting.
     * @param {?} options Flat list of all of the options.
     * @param {?} optionGroups Flat list of all of the option groups.
     * @return {?}
     */
    MdOption.countGroupLabelsBeforeOption = function (optionIndex, options, optionGroups) {
        if (optionGroups.length) {
            var /** @type {?} */ optionsArray = options.toArray();
            var /** @type {?} */ groups = optionGroups.toArray();
            var /** @type {?} */ groupCounter = 0;
            for (var /** @type {?} */ i = 0; i < optionIndex + 1; i++) {
                if (optionsArray[i].group && optionsArray[i].group === groups[groupCounter]) {
                    groupCounter++;
                }
            }
            return groupCounter;
        }
        return 0;
    };
    return MdOption;
}());
MdOption.decorators = [
    { type: _angular_core.Component, args: [{ selector: 'md-option, mat-option',
                host: {
                    'role': 'option',
                    '[attr.tabindex]': '_getTabIndex()',
                    '[class.mat-selected]': 'selected',
                    '[class.mat-option-multiple]': 'multiple',
                    '[class.mat-active]': 'active',
                    '[id]': 'id',
                    '[attr.aria-selected]': 'selected.toString()',
                    '[attr.aria-disabled]': 'disabled.toString()',
                    '[class.mat-option-disabled]': 'disabled',
                    '(click)': '_selectViaInteraction()',
                    '(keydown)': '_handleKeydown($event)',
                    'class': 'mat-option',
                },
                template: "<span *ngIf=\"multiple\"><mat-pseudo-checkbox class=\"mat-option-pseudo-checkbox\" [state]=\"selected ? 'checked' : ''\" [disabled]=\"disabled\"></mat-pseudo-checkbox></span><ng-content></ng-content><div class=\"mat-option-ripple\" mat-ripple [matRippleTrigger]=\"_getHostElement()\" [matRippleDisabled]=\"disabled || disableRipple\"></div>",
                encapsulation: _angular_core.ViewEncapsulation.None,
                preserveWhitespaces: false,
                changeDetection: _angular_core.ChangeDetectionStrategy.OnPush,
                viewProviders: [{ provide: MATERIAL_COMPATIBILITY_MODE, useValue: true }],
            },] },
];
/**
 * @nocollapse
 */
MdOption.ctorParameters = function () { return [
    { type: _angular_core.ElementRef, },
    { type: _angular_core.ChangeDetectorRef, },
    { type: MdOptgroup, decorators: [{ type: _angular_core.Optional },] },
]; };
MdOption.propDecorators = {
    'value': [{ type: _angular_core.Input },],
    'disabled': [{ type: _angular_core.Input },],
    'onSelectionChange': [{ type: _angular_core.Output },],
};
var MdOptionModule = (function () {
    function MdOptionModule() {
    }
    return MdOptionModule;
}());
MdOptionModule.decorators = [
    { type: _angular_core.NgModule, args: [{
                imports: [MdRippleModule, _angular_common.CommonModule, MdPseudoCheckboxModule],
                exports: [MdOption, MdOptgroup],
                declarations: [MdOption, MdOptgroup]
            },] },
];
/**
 * @nocollapse
 */
MdOptionModule.ctorParameters = function () { return []; };
/**
 * InjectionToken that can be used to specify the global placeholder options.
 */
var MD_PLACEHOLDER_GLOBAL_OPTIONS = new _angular_core.InjectionToken('md-placeholder-global-options');
/**
 * @deprecated
 */
var StyleModule = (function () {
    function StyleModule() {
    }
    return StyleModule;
}());
StyleModule.decorators = [
    { type: _angular_core.NgModule, args: [{
                imports: [_angular_cdk_a11y.A11yModule],
                exports: [_angular_cdk_a11y.A11yModule],
            },] },
];
/**
 * @nocollapse
 */
StyleModule.ctorParameters = function () { return []; };

var nextUniqueId$1 = 0;
/**
 * Single error message to be shown underneath the form field.
 */
var MdError = (function () {
    function MdError() {
        this.id = "mat-error-" + nextUniqueId$1++;
    }
    return MdError;
}());
MdError.decorators = [
    { type: _angular_core.Directive, args: [{
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
MdError.ctorParameters = function () { return []; };
MdError.propDecorators = {
    'id': [{ type: _angular_core.Input },],
};
/**
 * An interface which allows a control to work inside of a `MdFormField`.
 * @abstract
 */
var MdFormFieldControl = (function () {
    function MdFormFieldControl() {
    }
    /**
     * Sets the list of element IDs that currently describe this control.
     * @abstract
     * @param {?} ids
     * @return {?}
     */
    MdFormFieldControl.prototype.setDescribedByIds = function (ids) { };
    /**
     * Focuses this control.
     * @abstract
     * @return {?}
     */
    MdFormFieldControl.prototype.focus = function () { };
    return MdFormFieldControl;
}());
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
    return Error("A hint was already declared for 'align=\"" + align + "\"'.");
}
/**
 * \@docs-private
 * @return {?}
 */
function getMdFormFieldMissingControlError() {
    return Error('md-form-field must contain a MdFormFieldControl. ' +
        'Did you forget to add mdInput to the native input or textarea element?');
}
var nextUniqueId$2 = 0;
/**
 * Hint text to be shown underneath the form field control.
 */
var MdHint = (function () {
    function MdHint() {
        /**
         * Whether to align the hint label at the start or end of the line.
         */
        this.align = 'start';
        /**
         * Unique ID for the hint. Used for the aria-describedby on the form field control.
         */
        this.id = "mat-hint-" + nextUniqueId$2++;
    }
    return MdHint;
}());
MdHint.decorators = [
    { type: _angular_core.Directive, args: [{
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
MdHint.ctorParameters = function () { return []; };
MdHint.propDecorators = {
    'align': [{ type: _angular_core.Input },],
    'id': [{ type: _angular_core.Input },],
};
/**
 * The floating placeholder for an `MdFormField`.
 */
var MdPlaceholder = (function () {
    function MdPlaceholder() {
    }
    return MdPlaceholder;
}());
MdPlaceholder.decorators = [
    { type: _angular_core.Directive, args: [{
                selector: 'md-placeholder, mat-placeholder'
            },] },
];
/**
 * @nocollapse
 */
MdPlaceholder.ctorParameters = function () { return []; };
/**
 * Prefix to be placed the the front of the form field.
 */
var MdPrefix = (function () {
    function MdPrefix() {
    }
    return MdPrefix;
}());
MdPrefix.decorators = [
    { type: _angular_core.Directive, args: [{
                selector: '[mdPrefix], [matPrefix]',
            },] },
];
/**
 * @nocollapse
 */
MdPrefix.ctorParameters = function () { return []; };
/**
 * Suffix to be placed at the end of the form field.
 */
var MdSuffix = (function () {
    function MdSuffix() {
    }
    return MdSuffix;
}());
MdSuffix.decorators = [
    { type: _angular_core.Directive, args: [{
                selector: '[mdSuffix], [matSuffix]',
            },] },
];
/**
 * @nocollapse
 */
MdSuffix.ctorParameters = function () { return []; };
var nextUniqueId$1$1 = 0;
/**
 * Container for form controls that applies Material Design styling and behavior.
 */
var MdFormField = (function () {
    /**
     * @param {?} _elementRef
     * @param {?} _changeDetectorRef
     * @param {?} placeholderOptions
     */
    function MdFormField(_elementRef, _changeDetectorRef, placeholderOptions) {
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
        this._hintLabelId = "md-hint-" + nextUniqueId$1$1++;
        this._placeholderOptions = placeholderOptions ? placeholderOptions : {};
        this.floatPlaceholder = this._placeholderOptions.float || 'auto';
    }
    Object.defineProperty(MdFormField.prototype, "dividerColor", {
        /**
         * @deprecated Use `color` instead.
         * @return {?}
         */
        get: function () { return this.color; },
        /**
         * @param {?} value
         * @return {?}
         */
        set: function (value) { this.color = value; },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdFormField.prototype, "hideRequiredMarker", {
        /**
         * Whether the required marker should be hidden.
         * @return {?}
         */
        get: function () { return this._hideRequiredMarker; },
        /**
         * @param {?} value
         * @return {?}
         */
        set: function (value) {
            this._hideRequiredMarker = _angular_cdk_coercion.coerceBooleanProperty(value);
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdFormField.prototype, "_shouldAlwaysFloat", {
        /**
         * Whether the floating label should always float or not.
         * @return {?}
         */
        get: function () {
            return this._floatPlaceholder === 'always' && !this._showAlwaysAnimate;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdFormField.prototype, "_canPlaceholderFloat", {
        /**
         * Whether the placeholder can float or not.
         * @return {?}
         */
        get: function () { return this._floatPlaceholder !== 'never'; },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdFormField.prototype, "hintLabel", {
        /**
         * Text for the form field hint.
         * @return {?}
         */
        get: function () { return this._hintLabel; },
        /**
         * @param {?} value
         * @return {?}
         */
        set: function (value) {
            this._hintLabel = value;
            this._processHints();
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdFormField.prototype, "floatPlaceholder", {
        /**
         * Whether the placeholder should always float, never float or float as the user types.
         * @return {?}
         */
        get: function () { return this._floatPlaceholder; },
        /**
         * @param {?} value
         * @return {?}
         */
        set: function (value) {
            if (value !== this._floatPlaceholder) {
                this._floatPlaceholder = value || this._placeholderOptions.float || 'auto';
                this._changeDetectorRef.markForCheck();
            }
        },
        enumerable: true,
        configurable: true
    });
    /**
     * @return {?}
     */
    MdFormField.prototype.ngAfterContentInit = function () {
        var _this = this;
        this._validateControlChild();
        // Subscribe to changes in the child control state in order to update the form field UI.
        _angular_cdk_rxjs.startWith.call(this._control.stateChanges, null).subscribe(function () {
            _this._validatePlaceholders();
            _this._syncDescribedByIds();
            _this._changeDetectorRef.markForCheck();
        });
        var /** @type {?} */ ngControl = this._control.ngControl;
        if (ngControl && ngControl.valueChanges) {
            ngControl.valueChanges.subscribe(function () {
                _this._changeDetectorRef.markForCheck();
            });
        }
        // Re-validate when the number of hints changes.
        _angular_cdk_rxjs.startWith.call(this._hintChildren.changes, null).subscribe(function () {
            _this._processHints();
            _this._changeDetectorRef.markForCheck();
        });
        // Update the aria-described by when the number of errors changes.
        _angular_cdk_rxjs.startWith.call(this._errorChildren.changes, null).subscribe(function () {
            _this._syncDescribedByIds();
            _this._changeDetectorRef.markForCheck();
        });
    };
    /**
     * @return {?}
     */
    MdFormField.prototype.ngAfterContentChecked = function () {
        this._validateControlChild();
    };
    /**
     * @return {?}
     */
    MdFormField.prototype.ngAfterViewInit = function () {
        // Avoid animations on load.
        this._subscriptAnimationState = 'enter';
        this._changeDetectorRef.detectChanges();
    };
    /**
     * Determines whether a class from the NgControl should be forwarded to the host element.
     * @param {?} prop
     * @return {?}
     */
    MdFormField.prototype._shouldForward = function (prop) {
        var /** @type {?} */ ngControl = this._control ? this._control.ngControl : null;
        return ngControl && ((ngControl))[prop];
    };
    /**
     * Whether the form field has a placeholder.
     * @return {?}
     */
    MdFormField.prototype._hasPlaceholder = function () {
        return !!(this._control.placeholder || this._placeholderChild);
    };
    /**
     * Determines whether to display hints or errors.
     * @return {?}
     */
    MdFormField.prototype._getDisplayedMessages = function () {
        return (this._errorChildren && this._errorChildren.length > 0 &&
            this._control.errorState) ? 'error' : 'hint';
    };
    /**
     * Animates the placeholder up and locks it in position.
     * @return {?}
     */
    MdFormField.prototype._animateAndLockPlaceholder = function () {
        var _this = this;
        if (this._placeholder && this._canPlaceholderFloat) {
            this._showAlwaysAnimate = true;
            this._floatPlaceholder = 'always';
            _angular_cdk_rxjs.first.call(rxjs_observable_fromEvent.fromEvent(this._placeholder.nativeElement, 'transitionend')).subscribe(function () {
                _this._showAlwaysAnimate = false;
            });
            this._changeDetectorRef.markForCheck();
        }
    };
    /**
     * Ensure that there is only one placeholder (either `placeholder` attribute on the child control
     * or child element with the `md-placeholder` directive).
     * @return {?}
     */
    MdFormField.prototype._validatePlaceholders = function () {
        if (this._control.placeholder && this._placeholderChild) {
            throw getMdFormFieldPlaceholderConflictError();
        }
    };
    /**
     * Does any extra processing that is required when handling the hints.
     * @return {?}
     */
    MdFormField.prototype._processHints = function () {
        this._validateHints();
        this._syncDescribedByIds();
    };
    /**
     * Ensure that there is a maximum of one of each `<md-hint>` alignment specified, with the
     * attribute being considered as `align="start"`.
     * @return {?}
     */
    MdFormField.prototype._validateHints = function () {
        var _this = this;
        if (this._hintChildren) {
            var /** @type {?} */ startHint_1;
            var /** @type {?} */ endHint_1;
            this._hintChildren.forEach(function (hint) {
                if (hint.align == 'start') {
                    if (startHint_1 || _this.hintLabel) {
                        throw getMdFormFieldDuplicatedHintError('start');
                    }
                    startHint_1 = hint;
                }
                else if (hint.align == 'end') {
                    if (endHint_1) {
                        throw getMdFormFieldDuplicatedHintError('end');
                    }
                    endHint_1 = hint;
                }
            });
        }
    };
    /**
     * Sets the list of element IDs that describe the child control. This allows the control to update
     * its `aria-describedby` attribute accordingly.
     * @return {?}
     */
    MdFormField.prototype._syncDescribedByIds = function () {
        if (this._control) {
            var /** @type {?} */ ids = [];
            if (this._getDisplayedMessages() === 'hint') {
                var /** @type {?} */ startHint = this._hintChildren ?
                    this._hintChildren.find(function (hint) { return hint.align === 'start'; }) : null;
                var /** @type {?} */ endHint = this._hintChildren ?
                    this._hintChildren.find(function (hint) { return hint.align === 'end'; }) : null;
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
                ids = this._errorChildren.map(function (mdError) { return mdError.id; });
            }
            this._control.setDescribedByIds(ids);
        }
    };
    /**
     * Throws an error if the form field's control is missing.
     * @return {?}
     */
    MdFormField.prototype._validateControlChild = function () {
        if (!this._control) {
            throw getMdFormFieldMissingControlError();
        }
    };
    return MdFormField;
}());
MdFormField.decorators = [
    { type: _angular_core.Component, args: [{
                selector: 'md-input-container, mat-input-container, md-form-field, mat-form-field',
                template: "<div class=\"mat-input-wrapper mat-form-field-wrapper\"><div class=\"mat-input-flex mat-form-field-flex\" #connectionContainer><div class=\"mat-input-prefix mat-form-field-prefix\" *ngIf=\"_prefixChildren.length\"><ng-content select=\"[mdPrefix], [matPrefix]\"></ng-content></div><div class=\"mat-input-infix mat-form-field-infix\"><ng-content></ng-content><span class=\"mat-input-placeholder-wrapper mat-form-field-placeholder-wrapper\"><label class=\"mat-input-placeholder mat-form-field-placeholder\" [attr.for]=\"_control.id\" [attr.aria-owns]=\"_control.id\" [class.mat-empty]=\"_control.empty && !_shouldAlwaysFloat\" [class.mat-form-field-empty]=\"_control.empty && !_shouldAlwaysFloat\" [class.mat-float]=\"_canPlaceholderFloat\" [class.mat-form-field-float]=\"_canPlaceholderFloat\" [class.mat-accent]=\"color == 'accent'\" [class.mat-warn]=\"color == 'warn'\" #placeholder *ngIf=\"_hasPlaceholder()\"><ng-content select=\"md-placeholder, mat-placeholder\"></ng-content>{{_control.placeholder}} <span class=\"mat-placeholder-required mat-form-field-required-marker\" aria-hidden=\"true\" *ngIf=\"!hideRequiredMarker && _control.required\">*</span></label></span></div><div class=\"mat-input-suffix mat-form-field-suffix\" *ngIf=\"_suffixChildren.length\"><ng-content select=\"[mdSuffix], [matSuffix]\"></ng-content></div></div><div class=\"mat-input-underline mat-form-field-underline\" #underline [class.mat-disabled]=\"_control.disabled\"><span class=\"mat-input-ripple mat-form-field-ripple\" [class.mat-accent]=\"color == 'accent'\" [class.mat-warn]=\"color == 'warn'\"></span></div><div class=\"mat-input-subscript-wrapper mat-form-field-subscript-wrapper\" [ngSwitch]=\"_getDisplayedMessages()\"><div *ngSwitchCase=\"'error'\" [@transitionMessages]=\"_subscriptAnimationState\"><ng-content select=\"md-error, mat-error\"></ng-content></div><div class=\"mat-input-hint-wrapper mat-form-field-hint-wrapper\" *ngSwitchCase=\"'hint'\" [@transitionMessages]=\"_subscriptAnimationState\"><div *ngIf=\"hintLabel\" [id]=\"_hintLabelId\" class=\"mat-hint\">{{hintLabel}}</div><ng-content select=\"md-hint:not([align='end']), mat-hint:not([align='end'])\"></ng-content><div class=\"mat-input-hint-spacer mat-form-field-hint-spacer\"></div><ng-content select=\"md-hint[align='end'], mat-hint[align='end']\"></ng-content></div></div></div>",
                // MdInput is a directive and can't have styles, so we need to include its styles here.
                // The MdInput styles are fairly minimal so it shouldn't be a big deal for people who aren't using
                // MdInput.
                styles: [".mat-form-field{display:inline-block;position:relative;text-align:left}[dir=rtl] .mat-form-field{text-align:right}.mat-form-field-wrapper{position:relative}.mat-form-field-flex{display:inline-flex;align-items:baseline;width:100%}.mat-form-field-prefix,.mat-form-field-suffix{white-space:nowrap;flex:none}.mat-form-field-prefix .mat-icon,.mat-form-field-suffix .mat-icon{width:1em}.mat-form-field-prefix .mat-icon-button,.mat-form-field-suffix .mat-icon-button{font:inherit;vertical-align:baseline}.mat-form-field-prefix .mat-icon-button .mat-icon,.mat-form-field-suffix .mat-icon-button .mat-icon{font-size:inherit}.mat-form-field-infix{display:block;position:relative;flex:auto}.mat-form-field-autofill-control:-webkit-autofill+.mat-form-field-placeholder-wrapper .mat-form-field-placeholder{display:none}.mat-form-field-autofill-control:-webkit-autofill+.mat-form-field-placeholder-wrapper .mat-form-field-float{display:block;transition:none}.mat-form-field-placeholder-wrapper{position:absolute;left:0;box-sizing:content-box;width:100%;height:100%;overflow:hidden;pointer-events:none}.mat-form-field-placeholder{position:absolute;left:0;font:inherit;pointer-events:none;width:100%;white-space:nowrap;text-overflow:ellipsis;overflow:hidden;transform:perspective(100px);-ms-transform:none;transform-origin:0 0;transition:transform .4s cubic-bezier(.25,.8,.25,1),color .4s cubic-bezier(.25,.8,.25,1),width .4s cubic-bezier(.25,.8,.25,1);display:none}.mat-focused .mat-form-field-placeholder.mat-form-field-float,.mat-form-field-placeholder.mat-form-field-empty,.mat-form-field-placeholder.mat-form-field-float:not(.mat-form-field-empty){display:block}[dir=rtl] .mat-form-field-placeholder{transform-origin:100% 0;left:auto;right:0}.mat-form-field-placeholder:not(.mat-form-field-empty){transition:none}.mat-form-field-underline{position:absolute;height:1px;width:100%}.mat-form-field-underline.mat-disabled{background-position:0;background-color:transparent}.mat-form-field-underline .mat-form-field-ripple{position:absolute;height:1px;top:0;left:0;width:100%;transform-origin:50%;transform:scaleX(.5);visibility:hidden;transition:background-color .3s cubic-bezier(.55,0,.55,.2)}.mat-focused .mat-form-field-underline .mat-form-field-ripple{height:2px}.mat-focused .mat-form-field-underline .mat-form-field-ripple,.mat-form-field-invalid .mat-form-field-underline .mat-form-field-ripple{visibility:visible;transform:scaleX(1);transition:transform 150ms linear,background-color .3s cubic-bezier(.55,0,.55,.2)}.mat-form-field-subscript-wrapper{position:absolute;width:100%;overflow:hidden}.mat-form-field-placeholder-wrapper .mat-icon,.mat-form-field-subscript-wrapper .mat-icon{width:1em;height:1em;font-size:inherit;vertical-align:baseline}.mat-form-field-hint-wrapper{display:flex}.mat-form-field-hint-spacer{flex:1 0 1em}.mat-error{display:block} .mat-input-element{font:inherit;background:0 0;color:currentColor;border:none;outline:0;padding:0;margin:0;width:100%;max-width:100%;vertical-align:bottom}.mat-input-element:-moz-ui-invalid{box-shadow:none}.mat-input-element::placeholder{color:transparent!important}.mat-input-element::-moz-placeholder{color:transparent!important}.mat-input-element::-webkit-input-placeholder{color:transparent!important}.mat-input-element:-ms-input-placeholder{color:transparent!important}textarea.mat-input-element{resize:vertical;overflow:auto}"],
                animations: [
                    // TODO(mmalerba): Use angular animations for placeholder animation as well.
                    _angular_animations.trigger('transitionMessages', [
                        _angular_animations.state('enter', _angular_animations.style({ opacity: 1, transform: 'translateY(0%)' })),
                        _angular_animations.transition('void => enter', [
                            _angular_animations.style({ opacity: 0, transform: 'translateY(-100%)' }),
                            _angular_animations.animate('300ms cubic-bezier(0.55, 0, 0.55, 0.2)'),
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
                encapsulation: _angular_core.ViewEncapsulation.None,
                preserveWhitespaces: false,
                changeDetection: _angular_core.ChangeDetectionStrategy.OnPush,
            },] },
];
/**
 * @nocollapse
 */
MdFormField.ctorParameters = function () { return [
    { type: _angular_core.ElementRef, },
    { type: _angular_core.ChangeDetectorRef, },
    { type: undefined, decorators: [{ type: _angular_core.Optional }, { type: _angular_core.Inject, args: [MD_PLACEHOLDER_GLOBAL_OPTIONS,] },] },
]; };
MdFormField.propDecorators = {
    'color': [{ type: _angular_core.Input },],
    'dividerColor': [{ type: _angular_core.Input },],
    'hideRequiredMarker': [{ type: _angular_core.Input },],
    'hintLabel': [{ type: _angular_core.Input },],
    'floatPlaceholder': [{ type: _angular_core.Input },],
    'underlineRef': [{ type: _angular_core.ViewChild, args: ['underline',] },],
    '_connectionContainerRef': [{ type: _angular_core.ViewChild, args: ['connectionContainer',] },],
    '_placeholder': [{ type: _angular_core.ViewChild, args: ['placeholder',] },],
    '_control': [{ type: _angular_core.ContentChild, args: [MdFormFieldControl,] },],
    '_placeholderChild': [{ type: _angular_core.ContentChild, args: [MdPlaceholder,] },],
    '_errorChildren': [{ type: _angular_core.ContentChildren, args: [MdError,] },],
    '_hintChildren': [{ type: _angular_core.ContentChildren, args: [MdHint,] },],
    '_prefixChildren': [{ type: _angular_core.ContentChildren, args: [MdPrefix,] },],
    '_suffixChildren': [{ type: _angular_core.ContentChildren, args: [MdSuffix,] },],
};
var MdFormFieldModule = (function () {
    function MdFormFieldModule() {
    }
    return MdFormFieldModule;
}());
MdFormFieldModule.decorators = [
    { type: _angular_core.NgModule, args: [{
                declarations: [
                    MdError,
                    MdHint,
                    MdFormField,
                    MdPlaceholder,
                    MdPrefix,
                    MdSuffix,
                ],
                imports: [
                    _angular_common.CommonModule,
                    _angular_cdk_platform.PlatformModule,
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
MdFormFieldModule.ctorParameters = function () { return []; };

/**
 * \@docs-private
 * @param {?} type
 * @return {?}
 */
function getMdInputUnsupportedTypeError(type) {
    return Error("Input type \"" + type + "\" isn't supported by mdInput.");
}
// Invalid input type. Using one of these will throw an MdInputUnsupportedTypeError.
var MD_INPUT_INVALID_TYPES = [
    'button',
    'checkbox',
    'color',
    'file',
    'hidden',
    'image',
    'radio',
    'range',
    'reset',
    'submit'
];
var nextUniqueId = 0;
/**
 * Directive that allows a native input to work inside a `MdFormField`.
 */
var MdInput = (function () {
    /**
     * @param {?} _elementRef
     * @param {?} _renderer
     * @param {?} _platform
     * @param {?} ngControl
     * @param {?} _parentForm
     * @param {?} _parentFormGroup
     * @param {?} errorOptions
     */
    function MdInput(_elementRef, _renderer, _platform, ngControl, _parentForm, _parentFormGroup, errorOptions) {
        this._elementRef = _elementRef;
        this._renderer = _renderer;
        this._platform = _platform;
        this.ngControl = ngControl;
        this._parentForm = _parentForm;
        this._parentFormGroup = _parentFormGroup;
        /**
         * Variables used as cache for getters and setters.
         */
        this._type = 'text';
        this._disabled = false;
        this._required = false;
        this._uid = "md-input-" + nextUniqueId++;
        this._previousNativeValue = this.value;
        /**
         * Whether the input is focused.
         */
        this.focused = false;
        /**
         * Whether the input is in an error state.
         */
        this.errorState = false;
        /**
         * Stream that emits whenever the state of the input changes such that the wrapping `MdFormField`
         * needs to run change detection.
         */
        this.stateChanges = new rxjs_Subject.Subject();
        /**
         * Placeholder attribute of the element.
         */
        this.placeholder = '';
        this._neverEmptyInputTypes = [
            'date',
            'datetime',
            'datetime-local',
            'month',
            'time',
            'week'
        ].filter(function (t) { return _angular_cdk_platform.getSupportedInputTypes().has(t); });
        // Force setter to be called in case id was not specified.
        this.id = this.id;
        this._errorOptions = errorOptions ? errorOptions : {};
        this.errorStateMatcher = this._errorOptions.errorStateMatcher || defaultErrorStateMatcher;
        // On some versions of iOS the caret gets stuck in the wrong place when holding down the delete
        // key. In order to get around this we need to "jiggle" the caret loose. Since this bug only
        // exists on iOS, we only bother to install the listener on iOS.
        if (_platform.IOS) {
            _renderer.listen(_elementRef.nativeElement, 'keyup', function (event) {
                var el = event.target;
                if (!el.value && !el.selectionStart && !el.selectionEnd) {
                    // Note: Just setting `0, 0` doesn't fix the issue. Setting `1, 1` fixes it for the first
                    // time that you type text and then hold delete. Toggling to `1, 1` and then back to
                    // `0, 0` seems to completely fix it.
                    el.setSelectionRange(1, 1);
                    el.setSelectionRange(0, 0);
                }
            });
        }
    }
    Object.defineProperty(MdInput.prototype, "disabled", {
        /**
         * Whether the element is disabled.
         * @return {?}
         */
        get: function () { return this.ngControl ? this.ngControl.disabled : this._disabled; },
        /**
         * @param {?} value
         * @return {?}
         */
        set: function (value) { this._disabled = _angular_cdk_coercion.coerceBooleanProperty(value); },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdInput.prototype, "id", {
        /**
         * Unique id of the element.
         * @return {?}
         */
        get: function () { return this._id; },
        /**
         * @param {?} value
         * @return {?}
         */
        set: function (value) { this._id = value || this._uid; },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdInput.prototype, "required", {
        /**
         * Whether the element is required.
         * @return {?}
         */
        get: function () { return this._required; },
        /**
         * @param {?} value
         * @return {?}
         */
        set: function (value) { this._required = _angular_cdk_coercion.coerceBooleanProperty(value); },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdInput.prototype, "type", {
        /**
         * Input type of the element.
         * @return {?}
         */
        get: function () { return this._type; },
        /**
         * @param {?} value
         * @return {?}
         */
        set: function (value) {
            this._type = value || 'text';
            this._validateType();
            // When using Angular inputs, developers are no longer able to set the properties on the native
            // input element. To ensure that bindings for `type` work, we need to sync the setter
            // with the native property. Textarea elements don't support the type property or attribute.
            if (!this._isTextarea() && _angular_cdk_platform.getSupportedInputTypes().has(this._type)) {
                this._renderer.setProperty(this._elementRef.nativeElement, 'type', this._type);
            }
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdInput.prototype, "value", {
        /**
         * The input element's value.
         * @return {?}
         */
        get: function () { return this._elementRef.nativeElement.value; },
        /**
         * @param {?} value
         * @return {?}
         */
        set: function (value) {
            if (value !== this.value) {
                this._elementRef.nativeElement.value = value;
                this.stateChanges.next();
            }
        },
        enumerable: true,
        configurable: true
    });
    /**
     * @return {?}
     */
    MdInput.prototype.ngOnChanges = function () {
        this.stateChanges.next();
    };
    /**
     * @return {?}
     */
    MdInput.prototype.ngOnDestroy = function () {
        this.stateChanges.complete();
    };
    /**
     * @return {?}
     */
    MdInput.prototype.ngDoCheck = function () {
        if (this.ngControl) {
            // We need to re-evaluate this on every change detection cycle, because there are some
            // error triggers that we can't subscribe to (e.g. parent form submissions). This means
            // that whatever logic is in here has to be super lean or we risk destroying the performance.
            this._updateErrorState();
        }
        else {
            // When the input isn't used together with `@angular/forms`, we need to check manually for
            // changes to the native `value` property in order to update the floating label.
            this._dirtyCheckNativeValue();
        }
    };
    /**
     * Callback for the cases where the focused state of the input changes.
     * @param {?} isFocused
     * @return {?}
     */
    MdInput.prototype._focusChanged = function (isFocused) {
        if (isFocused !== this.focused) {
            this.focused = isFocused;
            this.stateChanges.next();
        }
    };
    /**
     * @return {?}
     */
    MdInput.prototype._onInput = function () {
        // This is a noop function and is used to let Angular know whenever the value changes.
        // Angular will run a new change detection each time the `input` event has been dispatched.
        // It's necessary that Angular recognizes the value change, because when floatingLabel
        // is set to false and Angular forms aren't used, the placeholder won't recognize the
        // value changes and will not disappear.
        // Listening to the input event wouldn't be necessary when the input is using the
        // FormsModule or ReactiveFormsModule, because Angular forms also listens to input events.
    };
    /**
     * Re-evaluates the error state. This is only relevant with \@angular/forms.
     * @return {?}
     */
    MdInput.prototype._updateErrorState = function () {
        var /** @type {?} */ oldState = this.errorState;
        var /** @type {?} */ ngControl = this.ngControl;
        var /** @type {?} */ parent = this._parentFormGroup || this._parentForm;
        var /** @type {?} */ newState = ngControl && this.errorStateMatcher(/** @type {?} */ (ngControl.control), parent);
        if (newState !== oldState) {
            this.errorState = newState;
            this.stateChanges.next();
        }
    };
    /**
     * Does some manual dirty checking on the native input `value` property.
     * @return {?}
     */
    MdInput.prototype._dirtyCheckNativeValue = function () {
        var /** @type {?} */ newValue = this.value;
        if (this._previousNativeValue !== newValue) {
            this._previousNativeValue = newValue;
            this.stateChanges.next();
        }
    };
    /**
     * Make sure the input is a supported type.
     * @return {?}
     */
    MdInput.prototype._validateType = function () {
        if (MD_INPUT_INVALID_TYPES.indexOf(this._type) > -1) {
            throw getMdInputUnsupportedTypeError(this._type);
        }
    };
    /**
     * Checks whether the input type is one of the types that are never empty.
     * @return {?}
     */
    MdInput.prototype._isNeverEmpty = function () {
        return this._neverEmptyInputTypes.indexOf(this._type) > -1;
    };
    /**
     * Checks whether the input is invalid based on the native validation.
     * @return {?}
     */
    MdInput.prototype._isBadInput = function () {
        // The `validity` property won't be present on platform-server.
        var /** @type {?} */ validity = ((this._elementRef.nativeElement)).validity;
        return validity && validity.badInput;
    };
    /**
     * Determines if the component host is a textarea. If not recognizable it returns false.
     * @return {?}
     */
    MdInput.prototype._isTextarea = function () {
        var /** @type {?} */ nativeElement = this._elementRef.nativeElement;
        // In Universal, we don't have access to `nodeName`, but the same can be achieved with `name`.
        // Note that this shouldn't be necessary once Angular switches to an API that resembles the
        // DOM closer.
        var /** @type {?} */ nodeName = this._platform.isBrowser ? nativeElement.nodeName : nativeElement.name;
        return nodeName ? nodeName.toLowerCase() === 'textarea' : false;
    };
    Object.defineProperty(MdInput.prototype, "empty", {
        /**
         * @return {?}
         */
        get: function () {
            return !this._isNeverEmpty() &&
                (this.value == null || this.value === '') &&
                // Check if the input contains bad input. If so, we know that it only appears empty because
                // the value failed to parse. From the user's perspective it is not empty.
                // TODO(mmalerba): Add e2e test for bad input case.
                !this._isBadInput();
        },
        enumerable: true,
        configurable: true
    });
    /**
     * @param {?} ids
     * @return {?}
     */
    MdInput.prototype.setDescribedByIds = function (ids) { this._ariaDescribedby = ids.join(' '); };
    /**
     * @return {?}
     */
    MdInput.prototype.focus = function () { this._elementRef.nativeElement.focus(); };
    return MdInput;
}());
MdInput.decorators = [
    { type: _angular_core.Directive, args: [{
                selector: "input[mdInput], textarea[mdInput], input[matInput], textarea[matInput]",
                host: {
                    'class': 'mat-input-element mat-form-field-autofill-control',
                    // Native input properties that are overwritten by Angular inputs need to be synced with
                    // the native input element. Otherwise property bindings for those don't work.
                    '[id]': 'id',
                    '[placeholder]': 'placeholder',
                    '[disabled]': 'disabled',
                    '[required]': 'required',
                    '[attr.aria-describedby]': '_ariaDescribedby || null',
                    '[attr.aria-invalid]': 'errorState',
                    '(blur)': '_focusChanged(false)',
                    '(focus)': '_focusChanged(true)',
                    '(input)': '_onInput()',
                },
                providers: [{ provide: MdFormFieldControl, useExisting: MdInput }],
            },] },
];
/**
 * @nocollapse
 */
MdInput.ctorParameters = function () { return [
    { type: _angular_core.ElementRef, },
    { type: _angular_core.Renderer2, },
    { type: _angular_cdk_platform.Platform, },
    { type: _angular_forms.NgControl, decorators: [{ type: _angular_core.Optional }, { type: _angular_core.Self },] },
    { type: _angular_forms.NgForm, decorators: [{ type: _angular_core.Optional },] },
    { type: _angular_forms.FormGroupDirective, decorators: [{ type: _angular_core.Optional },] },
    { type: undefined, decorators: [{ type: _angular_core.Optional }, { type: _angular_core.Inject, args: [MD_ERROR_GLOBAL_OPTIONS,] },] },
]; };
MdInput.propDecorators = {
    'disabled': [{ type: _angular_core.Input },],
    'id': [{ type: _angular_core.Input },],
    'placeholder': [{ type: _angular_core.Input },],
    'required': [{ type: _angular_core.Input },],
    'type': [{ type: _angular_core.Input },],
    'errorStateMatcher': [{ type: _angular_core.Input },],
};
/**
 * Directive to automatically resize a textarea to fit its content.
 */
var MdTextareaAutosize = (function () {
    /**
     * @param {?} _elementRef
     * @param {?} _platform
     */
    function MdTextareaAutosize(_elementRef, _platform) {
        this._elementRef = _elementRef;
        this._platform = _platform;
    }
    Object.defineProperty(MdTextareaAutosize.prototype, "minRows", {
        /**
         * @return {?}
         */
        get: function () { return this._minRows; },
        /**
         * @param {?} value
         * @return {?}
         */
        set: function (value) {
            this._minRows = value;
            this._setMinHeight();
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdTextareaAutosize.prototype, "maxRows", {
        /**
         * @return {?}
         */
        get: function () { return this._maxRows; },
        /**
         * @param {?} value
         * @return {?}
         */
        set: function (value) {
            this._maxRows = value;
            this._setMaxHeight();
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdTextareaAutosize.prototype, "_matAutosizeMinRows", {
        /**
         * @return {?}
         */
        get: function () { return this.minRows; },
        /**
         * @param {?} v
         * @return {?}
         */
        set: function (v) { this.minRows = v; },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MdTextareaAutosize.prototype, "_matAutosizeMaxRows", {
        /**
         * @return {?}
         */
        get: function () { return this.maxRows; },
        /**
         * @param {?} v
         * @return {?}
         */
        set: function (v) { this.maxRows = v; },
        enumerable: true,
        configurable: true
    });
    /**
     * Sets the minimum height of the textarea as determined by minRows.
     * @return {?}
     */
    MdTextareaAutosize.prototype._setMinHeight = function () {
        var /** @type {?} */ minHeight = this.minRows && this._cachedLineHeight ?
            this.minRows * this._cachedLineHeight + "px" : null;
        if (minHeight) {
            this._setTextareaStyle('minHeight', minHeight);
        }
    };
    /**
     * Sets the maximum height of the textarea as determined by maxRows.
     * @return {?}
     */
    MdTextareaAutosize.prototype._setMaxHeight = function () {
        var /** @type {?} */ maxHeight = this.maxRows && this._cachedLineHeight ?
            this.maxRows * this._cachedLineHeight + "px" : null;
        if (maxHeight) {
            this._setTextareaStyle('maxHeight', maxHeight);
        }
    };
    /**
     * @return {?}
     */
    MdTextareaAutosize.prototype.ngAfterViewInit = function () {
        if (this._platform.isBrowser) {
            this._cacheTextareaLineHeight();
            this.resizeToFitContent();
        }
    };
    /**
     * Sets a style property on the textarea element.
     * @param {?} property
     * @param {?} value
     * @return {?}
     */
    MdTextareaAutosize.prototype._setTextareaStyle = function (property, value) {
        var /** @type {?} */ textarea = (this._elementRef.nativeElement);
        textarea.style[property] = value;
    };
    /**
     * Cache the height of a single-row textarea.
     *
     * We need to know how large a single "row" of a textarea is in order to apply minRows and
     * maxRows. For the initial version, we will assume that the height of a single line in the
     * textarea does not ever change.
     * @return {?}
     */
    MdTextareaAutosize.prototype._cacheTextareaLineHeight = function () {
        var /** @type {?} */ textarea = (this._elementRef.nativeElement);
        // Use a clone element because we have to override some styles.
        var /** @type {?} */ textareaClone = (textarea.cloneNode(false));
        textareaClone.rows = 1;
        // Use `position: absolute` so that this doesn't cause a browser layout and use
        // `visibility: hidden` so that nothing is rendered. Clear any other styles that
        // would affect the height.
        textareaClone.style.position = 'absolute';
        textareaClone.style.visibility = 'hidden';
        textareaClone.style.border = 'none';
        textareaClone.style.padding = '0';
        textareaClone.style.height = '';
        textareaClone.style.minHeight = '';
        textareaClone.style.maxHeight = '';
        // In Firefox it happens that textarea elements are always bigger than the specified amount
        // of rows. This is because Firefox tries to add extra space for the horizontal scrollbar.
        // As a workaround that removes the extra space for the scrollbar, we can just set overflow
        // to hidden. This ensures that there is no invalid calculation of the line height.
        // See Firefox bug report: https://bugzilla.mozilla.org/show_bug.cgi?id=33654
        textareaClone.style.overflow = 'hidden'; /** @type {?} */
        ((textarea.parentNode)).appendChild(textareaClone);
        this._cachedLineHeight = textareaClone.clientHeight; /** @type {?} */
        ((textarea.parentNode)).removeChild(textareaClone);
        // Min and max heights have to be re-calculated if the cached line height changes
        this._setMinHeight();
        this._setMaxHeight();
    };
    /**
     * @return {?}
     */
    MdTextareaAutosize.prototype.ngDoCheck = function () {
        this.resizeToFitContent();
    };
    /**
     * Resize the textarea to fit its content.
     * @return {?}
     */
    MdTextareaAutosize.prototype.resizeToFitContent = function () {
        var /** @type {?} */ textarea = (this._elementRef.nativeElement);
        var /** @type {?} */ value = textarea.value;
        // Only resize of the value changed since these calculations can be expensive.
        if (value === this._previousValue) {
            return;
        }
        // Reset the textarea height to auto in order to shrink back to its default size.
        // Also temporarily force overflow:hidden, so scroll bars do not interfere with calculations.
        textarea.style.height = 'auto';
        textarea.style.overflow = 'hidden';
        // Use the scrollHeight to know how large the textarea *would* be if fit its entire value.
        textarea.style.height = textarea.scrollHeight + "px";
        textarea.style.overflow = '';
        this._previousValue = value;
    };
    return MdTextareaAutosize;
}());
MdTextareaAutosize.decorators = [
    { type: _angular_core.Directive, args: [{
                selector: "textarea[md-autosize], textarea[mdTextareaAutosize],\n             textarea[mat-autosize], textarea[matTextareaAutosize]",
                exportAs: 'mdTextareaAutosize, matTextareaAutosize',
                host: {
                    // Textarea elements that have the directive applied should have a single row by default.
                    // Browsers normally show two rows by default and therefore this limits the minRows binding.
                    'rows': '1',
                },
            },] },
];
/**
 * @nocollapse
 */
MdTextareaAutosize.ctorParameters = function () { return [
    { type: _angular_core.ElementRef, },
    { type: _angular_cdk_platform.Platform, },
]; };
MdTextareaAutosize.propDecorators = {
    'minRows': [{ type: _angular_core.Input, args: ['mdAutosizeMinRows',] },],
    'maxRows': [{ type: _angular_core.Input, args: ['mdAutosizeMaxRows',] },],
    '_matAutosizeMinRows': [{ type: _angular_core.Input, args: ['matAutosizeMinRows',] },],
    '_matAutosizeMaxRows': [{ type: _angular_core.Input, args: ['matAutosizeMaxRows',] },],
};
var MdInputModule = (function () {
    function MdInputModule() {
    }
    return MdInputModule;
}());
MdInputModule.decorators = [
    { type: _angular_core.NgModule, args: [{
                declarations: [
                    MdInput,
                    MdTextareaAutosize,
                ],
                imports: [
                    _angular_common.CommonModule,
                    MdFormFieldModule,
                    _angular_cdk_platform.PlatformModule,
                ],
                exports: [
                    // We re-export the `MdFormFieldModule` since `MdInput` will almost always be used together with
                    // `MdFormField`.
                    MdFormFieldModule,
                    MdInput,
                    MdTextareaAutosize,
                ],
            },] },
];
/**
 * @nocollapse
 */
MdInputModule.ctorParameters = function () { return []; };

exports.MdInputModule = MdInputModule;
exports.MdTextareaAutosize = MdTextareaAutosize;
exports.MdInput = MdInput;
exports.getMdInputUnsupportedTypeError = getMdInputUnsupportedTypeError;
exports.MatInput = MdInput;
exports.MatInputModule = MdInputModule;
exports.MatTextareaAutosize = MdTextareaAutosize;

Object.defineProperty(exports, '__esModule', { value: true });

})));
//# sourceMappingURL=material-input.umd.js.map
