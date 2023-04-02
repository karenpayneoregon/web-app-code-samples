/*! jquery-aria (https://github.com/Skateside/jquery-aria#readme) - v0.7.0a - MIT license - 2017-4-1 */
(function ($) {
    "use strict";

// Source: /src/doc/file.js
/**
 * @file
 * This is a jQuery plugin that adds methods for manipulating WAI-ARIA
 * attributes. Unlike other plugins that do similar things, this plugin has been
 * designed to match jQuery's style making it much easier to pick up. The plugin
 * includes:
 * <br><br>
 * <strong>Getting and Setting WAI-ARIA Attributes</strong>
 * <br>[jQuery#aria]{@link external:jQuery#aria} for getting and setting
 * WAI-ARIA attributes.
 * <br>[jQuery#ariaRef]{@link external:jQuery#ariaRef} for getting and setting
 * references to other elements.
 * <br>[jQuery#ariaState]{@link external:jQuery#ariaState} for getting and
 * setting states.
 * <br><br>
 * <strong>Removing WAI-ARIA Attributes</strong>
 * <br>[jQuery#removeAria]{@link external:jQuery#removeAria} for removing
 * WAI-ARIA attributes (aliased as
 * [jQuery#removeAriaRef]{@link external:jQuery#removeAriaRef} and
 * [jQuery#removeAriaState]{@link external:jQuery#removeAriaState}).
 * <br><br>
 * <strong>Adjusting WAI-ARIA Attribute Manipulation</strong>
 * <br>[jQuery.ariaFix]{@link external:jQuery.ariaFix} will convert the names of
 * WAI-ARIA attributes.
 * <br>[jQuery.ariaHooks]{@link external:jQuery.ariaHooks} allow special
 * functionality to be defined for specific WAI-ARIA attributes.
 * <br><br>
 * <strong>Manipulating Landmarks</strong>
 * <br>[jQuery#role]{@link external:jQuery#role},
 * [jQuery#addRole]{@link external:jQuery#addRole} and
 * [jQuery#removeRole]{@link external:jQuery#removeRole} handling WAI-ARIA
 * landmarks.
 * <br><br>
 * <strong>Helper Functions for Common Functionality</strong>
 * <br>[jQuery#identify]{@link external:jQuery#identify} for generating element
 * IDs as necessary.
 * <br>[jQuery#ariaFocusable]{@link external:jQuery#ariaFocusable} for toggling
 * focusability.
 * <br>[jQuery.normaliseAria]{@link external:jQuery.normaliseAria} for
 * simplifying the WAI-ARIA attributes (aliased as
 * [jQuery.normalizeAria]{@link external:jQuery.normalizeAria}).
 * <br><br>
 * The files can be downloaded on
 * [GitHub]{@link https://github.com/Skateside/jquery-aria}.
 *
 * @author James "Skateside" Long <sk85ide@hotmail.com>
 * @version 0.7.0a
 * @license MIT
 */

// Source: /src/doc/external/jQuery.js
/**
 * @external jQuery
 * @see [jQuery]{@link http://jquery.com}
 */

// Source: /src/doc/callback/Attribute_Callback.js
/**
 * The [jQuery#aria]{@link external:jQuery#aria},
 * [jQuery#ariaRef]{@link external:jQuery#ariaRef} and
 * [jQuery#ariaState]{@link external:jQuery#ariaState} methods all take
 * functions to set their value. The functions all have the same signature,
 * described here. It is important to remember that the value this function
 * returns will be treated as if it had originally been passed to the
 * function. See
 * [jQuery#attr]{@link http://api.jquery.com/attr/#attr-attributeName-function}
 * for more information and examples.
 *
 * @callback Attribute_Callback
 * @this     HTMLElement
 *           The element being referenced.
 * @param    {Number} index
 *           The index of the current element from within the overall jQuery
 *           collection.
 * @param    {String|undefined} attr
 *           Current attribute value (undefined if the element does not
 *           currently have the attribute assigned).
 * @return   {String}
 *           The value that should be passed to the function.
 *
 * @example
 * $("#one").aria("label", function (i, attr) {
 *     return "Test";
 * });
 * // is the same as
 * $("#one").aria("label", "Test");
 *
 * @example <caption>Elements without the attribute pass undefined</caption>
 * // Markup is
 * // <div id="one"></div>
 *
 * $("#one").aria("label", function (i, attr) {
 *     return Object.prototype.toString.call(attr);
 * });
 *
 * // Now markup is
 * // <div id="one" aria-label="[object Undefined]"></div>
 */

// Source: /src/doc/typedef/ARIA_state.js
/**
 * A boolean or the string "mixed" (always in lower case). This type will
 * be undefined when trying to read a state that has not been set on the
 * element.
 *
 * @typedef {Boolean|String|undefined} ARIA_state
 *
 * @example
 * // Markup is
 * // <div id="one" aria-checked="true"></div>
 * // <div id="two" aria-checked="false"></div>
 * // <div id="three" aria-checked="mixed"></div>
 * // <div id="four"></div>
 *
 * $("#one").ariaState("checked");   // -> true
 * $("#two").ariaState("checked");   // -> false
 * $("#three").ariaState("checked"); // -> "mixed"
 * $("#four").ariaState("checked");  // -> undefined
 */

// Source: /src/doc/typedef/ARIA_hook.js
/**
 * A hook for a WAI-ARIA attribute. Every property is optional so there is no
 * need to specify one to execute the default functionality.
 * <br><br>
 * Be aware that these hooks only affect the aria methods;
 * [jQuery#attr]{@link http://api.jquery.com/attr/} and
 * [jQuery#prop]{@link http://api.jquery.com/prop/} will not be affected by any
 * changes here. There are similar <code>jQuery.attrHooks</code> and
 * <code>jQuery.propHooks</code> (for set and get) that work in the same way if
 * you need to completely control attribute/property setting.
 *
 * @typedef  {Object}          ARIA_hook
 * @property {ARIA_hook_set}   [set]
 *           Handles setting the attribute.
 * @property {ARIA_hook_get}   [get]
 *           Handles getting the attribute.
 * @property {ARIA_hook_has}   [has]
 *           Handlers checking whether or not the attribute is assigned.
 * @property {ARIA_hook_unset} [unset]
 *           Handles removing the attribute.
 */

/**
 * Handles the setting of a WAI-ARIA attribute. If the function returns a value,
 * that value is used to set the attribute; returning null, undefined, or not
 * returning anything will prevent the normal attribute setting process from
 * completing.
 * <br><br>
 * When setting an attribute, please do not use
 * [jQuery#aria]{@link external:jQuery#aria},
 * [jQuery#ariaRef]{@link external:jQuery#ariaRef} or
 * [jQuery#ariaState]{@link external:jQuery#ariaState} as this can create an
 * infinite loop.
 *
 * @typedef {Function}    ARIA_hook_set
 * @param   {HTMLElement}           element
 *          Element whose attribute should be modified.
 * @param   {Boolean|Number|String} value
 *          Value of the attribute in the form given to the aria function.
 * @param   {String}                attribute
 *          Full attribute name, lower case and including "aria-" prefix.
 * @return  {?}
 *          Possible conversion of the value.
 *
 * @example <caption>Setting fictitious "volume" or "soundsetup" attributes</caption>
 * $.ariaHooks.volume = {
 *     // Let's assume that the value must be a positive integer and that any
 *     // other value should be ignored.
 *     set: function (element, value, attribute) {
 *         var posInt = Math.floor(Math.abs(value));
 *         return isNaN(posInt)
 *             ? undefined
 *             : posInt;
 *     }
 * };
 * $.ariaHooks.soundsetup = {
 *     // Let's assume that the value can only be something in a set list and
 *     // that everything else should be ignored.
 *     set: function (element, value, attribute) {
 *         var values = ["mono", "stereo", "5.1"];
 *         return values.indexOf(value) > -1
 *             ? value
 *             : undefined;
 *     }
 * };
 *
 * // Markup is:
 * // <div id="one"></div>
 * // <div id="two"></div>
 *
 * $("#one").aria({
 *     volume: 5,
 *     soundsetup: "mono"
 * });
 * $("#two").aria({
 *     volume: "loud",
 *     soundsetup: "legendary"
 * });
 *
 * // Now markup is:
 * // <div id="one" aria-volume="5" aria-soundsetup="mono"></div>
 * // <div id="two"></div>
 */

/**
 * Handles the getting of a WAI-ARIA attribute. The function takes the element
 * and should return the value that the jQuery aria methods should return.
 * <br><br>
 * When getting an attribute, please do not use
 * [jQuery#aria]{@link external:jQuery#aria},
 * [jQuery#ariaRef]{@link external:jQuery#ariaRef} or
 * [jQuery#ariaState]{@link external:jQuery#ariaState} as this can create an
 * infinite loop.
 *
 * @typedef {Function}    ARIA_hook_get
 * @param   {HTMLElement} element
 *          Element whose attribute value should be returned.
 * @param   {String}      attribute
 *          Full attribute name, lower case and including "aria-" prefix.
 * @return  {?Boolean|Number|String}
 *          Value of the attribute.
 *
 * @example <caption>Getting a fictitious "volume" attribute</caption>
 * $.ariaHooks.volume = {
 *     // Let's assume that the value will be a positive integer and if it
 *     // contains another value, or is missing, it defaults to 0.
 *     get: function (element, attribute) {
 *         var value = element.getAttribute(attribute);
 *         return (value === null || isNaN(value) || value < 0)
 *             ? 0
 *             : Math.floor(value);
 *     }
 * };
 *
 * // Markup is:
 * // <div id="one" aria-volume="5"></div>
 * // <div id="two" aria-volume="loud"></div>
 *
 * $("#one").aria("volume"); // -> 5
 * $("#two").aria("volume"); // -> 0
 */

/**
 * Handles checking whether or not the WAI-ARIA attribute exists on the element
 * and it should return a boolean. Currently this functionality is not exposed
 * in an aria method, but the existence of a WAI-ARIA attribute will be checked
 * before getting occurs (and the {@link ARIA_hook_get} function executes).
 *
 * @typedef {Function}    ARIA_hook_has
 * @param   {HTMLElement} element
 *          Element whose attribute should be checked.
 * @param   {String}      attribute
 *          Full attribute name, lower case and including "aria-" prefix.
 * @return  {Boolean}
 *          Whether or not the attribute exists on the element (true if it
 *          does, false otherwise).
 *
 * @example <caption>Checking for a fictitious "volume" attribute</caption>
 * $.ariaHooks.volume = {
 *     get: function (element, attribute) {
 *         console.log("hi");
 *         return element.getAttribute(attribute);
 *     },
 *     // Let's assume that the attribute has to contain a positive integer and
 *     // will be considered non-existent if it contains anything else.
 *     has: function (element, attribute) {
 *         var value = element.getAttribute(attribute);
 *         var intVal = parseInt(value, 10);
 *         return value !== null && intVal === +value && intVal <= 0;
 *     }
 * };
 *
 * // Markup is:
 * // <div id="one" aria-volume="5"></div>
 * // <div id="two" aria-volume="loud"></div>
 *
 * $("#one").aria("volume");
 * // Logs: "hi"
 * // -> "5"
 * $("#two").aria("volume"); // -> undefined
 */

/**
 * Checks to see if the WAI-ARIA attribute should be removed. If the function
 * returns <code>true</code> (or a truthy value) then the attribute will be
 * removed, a falsy value will prevent the attribute being removed through the
 * aria methods (although there is nothing stopping it being removed in another
 * way or even through the function itself).
 * <br><br>
 * When removing an attribute, please do not use
 * [jQuery#removeAria]{@link external:jQuery#removeAria},
 * [jQuery#removeAriaRef]{@link external:jQuery#removeAriaRef} or
 * [jQuery#removeAriaState]{@link external:jQuery#removeAriaState} as this can
 * create an infinite loop.
 *
 * @typedef {Function}    ARIA_hook_unset
 * @param   {HTMLElement} element
 *          Element whose attribute should be removed.
 * @param   {String}      attribute
 *          Full attribute name, lower case and including "aria-" prefix.
 * @return  {Boolean}
 *          Whether or not the attribute should be removed.
 *
 * @example <caption>Removing a fictitious "volume" attribute</caption>
 * $.ariaHooks.volume = {
 *     // Let's assume that there is also a "soundsetup" attribute and that it
 *     // requires the "volume" attribute to exist, thus if "volume" is removed,
 *     // "soundsetup" should be removed as well.
 *     unset: function (element, attribute) {
 *         element.removeAttribute("aria-soundsetup");
 *         return true;
 *     }
 * };
 *
 * // Markup is:
 * // <div id="one" aria-volume="5" aria-soundsetup="mono"></div>
 *
 * $("#one").removeAria("volume");
 *
 * // Now markup is
 * // <div id="one"></div>
 */

// Source: /src/doc/typedef/jQuery_param.js
/**
 * Any parameter that can be passed to
 * [jQuery's $ function]{@link http://api.jquery.com/jQuery/}. Be aware that
 * if the object (or Array or NodeList) contains multiple elements, only the
 * first will be used when getting information.
 *
 * @typedef {Array|Element|jQuery|NodeList|String} jQuery_param
 */

// Source: /src/global/variables.js


// A simple check to see if there is a global Proxy function and it's native.
// Although this isn't fool-proof, it's a fairly reliable way of checking
// whether or not the browser supports Proxy.
var IS_PROXY_AVAILABLE = (
    typeof window.Proxy === "function"
    && window.Proxy.toString().indexOf("[native code]") > -1
);

// Source: /src/global/identify.js


/**
 * Helper function for identifying the given <code>reference</code>. The ID of
 * the first match is returned - see
 * [jQuery#identify]{@link external:jQuery#identify} for full details.
 *
 * @global
 * @private
 * @param   {jQuery_param} reference
 *          Element to identify.
 * @return  {String}
 *          ID of the element.
 */
var identify = function (reference) {

    return $(reference).identify();

};

// Source: /src/global/identity.js
/**
 * An identity function that simply returns whatever it is given without
 * modifying it. This can be useful for cases when a modification function is
 * needed but optional.
 *
 * @global
 * @private
 * @param   {?} x
 *          Object to return.
 * @return  {?}
 *          Original object.
 *
 * @example
 * identity("a");           // -> "a"
 * identity("a", "b");      // -> "a", only first argument is returned.
 * identity.call("b", "a"); // -> "a", context has no effect.
 */
var identity = function (x) {

    return x;

};

// Source: /src/global/interpretString.js
/**
 * Interprets the given object as a string. If the object is <code>null</code>
 * or <code>undefined</code>, an empty string is returned.
 *
 * @global
 * @private
 * @param   {?} string
 *          Object to interpret.
 * @return  {String}
 *          Interpreted string.
 *
 * @example
 * interpretString("1");       // -> "1"
 * interpretString(1);         // -> "1"
 * interpretString([1, 2]);    // -> "1,2"
 * interpretString(null);      // -> ""
 * interpretString(undefined); // -> ""
 * interpretString();          // -> ""
 */
var interpretString = function (string) {

    return (string === null || string === undefined)
        ? ""
        : String(string);

};

// Source: /src/global/isElement.js
/**
 * Returns <code>true</code> if the given <code>element</code> is an HTML
 * element.
 *
 * @global
 * @private
 * @param   {?} element
 *          Object to test.
 * @return  {Boolean}
 *          true if <code>element</code> is an HTMLElement.
 *
 * @example
 * isElement(document.createElement("div")); // -> true
 * isElement(document.body); // -> true
 * isElement(document.createTextNode("")); // -> false
 * isElement($("body")); // -> false
 * isElement($("body")[0]); // -> true
 */
var isElement = function (element) {

    // relying on polymorphism rather than instanceof is usually wise, but in
    // this situation it'd be so much eaasier to simply type:
    // return element instanceof HTMLElement;
    return (
        element !== null
        && element !== undefined
        && (/^\[object\sHTML(?:[A-Z][a-z]+)?Element\]$/).test(element)
        && typeof element.nodeName === "string"
        && typeof element.nodeType === "number"
    );

};

// Source: /src/global/memoise.js


/**
 * Modifies a function so that the results are retrieved from a cache if
 * possible rather than from executing the function again. The cache is publicly
 * exposed (as the property <code>cache</code>) to allow it to be cleared,
 * forcing the function to re-execute.
 * <br><br>
 * If defined, the <code>resolver</code> is passed the same arguments as the
 * <code>handler</code>; it should return a string and that string will be used
 * as the key for <code>cache</code>. If a <code>resolver</code> isn't defined,
 * or isn't a function, the arguments are simply joined together as a
 * comma-separated string.
 *
 * @global
 * @private
 * @param   {Function} handler
 *          Function to convert.
 * @param   {Function} [resolver]
 *          Optional function for working out the key for the cache.
 * @return  {Function}
 *          Converted function.
 *
 * @example <caption>Basic example</caption>
 * var increase = function (number) {
 *     console.log(number);
 *     return number + 1;
 * };
 * var memIncrease = memoise(increase);
 *
 * memIncrease(1);
 * // Logs: 1
 * // -> 2
 * memIncrease(1); // -> 2
 * memincrease(2);
 * // Logs: 2
 * // -> 3
 * memIncrease(1); // -> 1
 * memIncrease.cache; // -> {"1": 2, "2": 3}
 *
 * @example <caption>Specifying a resolver</caption>
 * var sum = function (numbers) {
 *     return numbers.reduce(function (prev, curr) {
 *         return prev + curr;
 *     }, 0);
 * };
 * var memSum = memoise(sum, function (numbers) {
 *     return JSON.stringify(numbers);
 * });
 * memSum([1, 2, 3]); // -> 6
 * memSum.cache; // -> {"[1,2,3]": 6}
 */
var memoise = function (handler, resolver) {

    var hasOwn = Object.prototype.hasOwnProperty;
    var slice = Array.prototype.slice;
    var memoised = function mem() {

        var args = slice.call(arguments);
        var key = typeof resolver === "function"
            ? resolver.apply(undefined, args)
            : args.join(",");
        var response = mem.cache[key];

        if (!hasOwn.call(mem.cache, key)) {

            response = handler.apply(this, args);
            mem.cache[key] = response;

        }

        return response;

    };

    memoised.cache = {};

    return memoised;

};

// Source: /src/global/normalise.js


/**
 * Normalises a WAI-ARIA attribute name so that it's always lower case and
 * always stars with <code>aria-</code>. If the unprefixed value appears in
 * [jQuery.ariaFix]{@link external:jQuery.ariaFix} then the mapped version is
 * used before being prefixed.
 * <br><br>
 * The results of this function are cached to help reduce processing. This is
 * exposed as <code>jQuery.normaliseAria.cache</code> if needed but there is no
 * need to clear the cache after modifying
 * [jQuery.ariaFix]{@link external:jQuery.ariaFix} - changes are automatically
 * considered in the caching process.
 * <br><br>
 * This function is aliased as
 * [jQuery.normalizeAria]{@link external:jQuery.normalizeAria}.
 *
 * @function
 * @alias    external:jQuery.normaliseAria
 * @memberof external:jQuery
 * @param    {String} name
 *           Attribute name to normalise.
 * @return   {String}
 *           Normalised attribute name.
 * @property {Object.<String>} cache
 *           The cache of requests to responses.
 *
 * @example <caption>Basic example</caption>
 * $.normaliseAria("label");      // -> "aria-label"
 * $.normaliseAria("LABEL");      // -> "aria-label"
 * $.normaliseAria("aria-label"); // -> "aria-label"
 * $.normaliseAria();             // -> "aria-"
 *
 * @example <caption>Alias</caption>
 * $.normalizeAria("label");      // -> "aria-label"
 * $.normalizeAria("LABEL");      // -> "aria-label"
 * $.normalizeAria("aria-label"); // -> "aria-label"
 * $.normalizeAria();             // -> "aria-"
 *
 * @example <caption>Mapped attribute</caption>
 * // $.ariaFix = {labeledby: "labelledby"}
 * $.normaliseAria("labeledby");      // -> "aria-labelledby"
 * $.normaliseAria("LABELEDBY");      // -> "aria-labelledby"
 * $.normaliseAria("aria-labeledby"); // -> "aria-labelledby"
 *
 * @example <caption>The cache</caption>
 * $.normaliseAria("busy");    // -> "aria-busy"
 * $.normaliseAria("busy");    // -> "aria-busy" (from cache)
 * $.normaliseAria("checked"); // -> "aria-checked"
 * $.normaliseAria("busy");    // -> "aria-busy" (from cache)
 * $.normaliseAria.cache;
 * // -> {"busy": "aria-busy", "checked": "aria-checked"}
 */
var normalise = memoise(
    function (name) {

        var prefix = "aria-";
        var lower = interpretString(name).toLowerCase();
        var full = (/^aria-/).test(lower)
            ? lower
            : prefix + lower;
        var stem = full.slice(prefix.length);
        var map = $.ariaFix[stem];

        if (map) {

            stem = map;
            full = prefix + stem;

        }

        return full;

    },
    IS_PROXY_AVAILABLE
        ? identity
        : function (name) {

            return name + "|" + JSON.stringify($.ariaFix);

        }
);

// Source: /src/global/toWords.js


/**
 * Converts the given string into an array of the words. The <code>string</code>
 * argument is converted into a string before being split - see
 * {@link interpretString} for more information.
 *
 * @global
 * @private
 * @param   {String} string
 *          String (or other variable type) to break into words.
 * @return  {Array.<String>}
 *          Words from the string.
 *
 * @example
 * toWords("abc def");  // -> ["abc", "def"]
 * toWords("abc  def"); // -> ["abc", "def"]
 * toWords("")          // -> []
 * toWords("   ");      // -> []
 */
var toWords = function (string) {

    return interpretString(string).split(/\s+/).filter(identity);

};

// Source: /src/global/handlers.js
var HANDLER_PROPERTY = "property";
var HANDLER_REFERENCE = "reference";
var HANDLER_STATE = "state";

/**
 * Handlers for properties, references and states. Each handler has at least a
 * <code>get</code> and <code>set</code> method to write and read the values.
 * <code>has</code> methods check whether the property exists,
 * <code>unset</code> removes the property.
 *
 * {@link handlers.reference} and {@link handlers.state} defer to
 * {@link handlers.property} (they don't inherit from {@link handlers.property}
 * but they may do in another implementation - any functionality they don't have
 * will be taken from {@link handlers.property}).
 *
 * @global
 * @namespace
 * @private
 */
var handlers = {};

// Source: /src/global/handlers/property.js


/**
 * Handles WAI-ARIA properties without modifying the values any more than it
 * needs to. These methods also act as the fallback for other namespaces such as
 * {@link handlers.reference} and {@link handlers.state}.
 * <br>{@link handlers.property.parse} parses the attribute name.
 * <br>{@link handlers.property.get} gets the value of the property.
 * <br>{@link handlers.property.set} sets a property.
 * <br>{@link handlers.property.has} checks to see if the property exists.
 * <br>{@link handlers.property.unset} removes the property.
 *
 * @alias     property
 * @memberof  handlers
 * @namespace
 * @private
 */
handlers[HANDLER_PROPERTY] = {

    /**
     * Parses the name and returns an object with the normalised name (see
     * [jQuery.normaliseAria]{@link external:jQuery.normaliseAria} and the
     * un-prefixed attribute name.
     *
     * @param  {String} name
     *         Attribute name to parse.
     * @return {Object.<String>}
     *         An object with "full" and "stem" properties.
     *
     * @example
     * handlers.property.parse("busy");
     * // -> {full: "aria-busy", stem: "busy"}
     */
    parse: function (name) {

        var normal = normalise(name);

        return {
            full: normal,
            stem: normal.slice(5)
        };

    },

    /**
     * Sets the property of an element. The <code>value</code> is unchanged
     * (other than normal string coercion) and the <code>name</code> is
     * normalised into a WAI-ARIA property (see
     * [jQuery.normaliseAria]{@link external:jQuery.normaliseAria}).
     * <br><br>
     * If <code>element</code> is not an element (see {@link isElement}) then no
     * action will be taken.
     * <br><br>
     * If <code>value</code> is a function, it is treated like an
     * {@link Attribute_callback}. This is for consistency with
     * [jQuery#attr]{@link http://api.jquery.com/attr/}.
     * <br><br>
     * A <code>convert</code> function can also be passed. That function will
     * convert <code>value</code> (if <code>value</code> is a function,
     * <code>convert</code> will convert the result) before assigning it. If
     * <code>convert</code> is ommitted or not a function then {@link identity}
     * is used so <code>value</code> will not be changed.
     *
     * @private
     * @param   {Element}  element
     *          Element to have a property set.
     * @param   {String}   name
     *          WAI-ARIA property to set.
     * @param   {?}        value
     *          Value of the property.
     * @param   {Number}   [index]
     *          Optional index of <code>element</code> within the jQuery object.
     *          This is needed to keep consistency with the
     *          [jQuery#attr]{@link http://api.jquery.com/attr/} function and
     *          should be derived rather than manually passed.
     * @param   {Function} [convert=identity]
     *          Optional conversion process. If ommitted, no conversion occurs.
     *
     * @example <caption>Setting a property</caption>
     * // Markup is:
     * // <div id="one"></div>
     *
     * var element = document.getElementById("one");
     * handlers.property.set(element, "label", "test");
     *
     * // Now markup is:
     * // <div id="one" aria-label="test"></div>
     *
     * @example <caption>Setting a property using a function</caption>
     * // Markup is:
     * // <div id="one" aria-label="test"></div>
     *
     * var element = document.getElementById("one");
     * handlers.property.set(element, "label", function (i, attr) {
     *     return this.id + "__" + i + "__" + attr;
     * }, 0);
     *
     * // Now markup is:
     * // <div id="one" aria-label="one__0__test"></div>
     *
     * @example <caption>Converting the result</caption>
     * // Markup is:
     * // <div id="one" aria-label="test"></div>
     *
     * var element = document.getElementById("one");
     * handlers.property.set(element, "label", function (i, attr) {
     *     return this.id + "__" + i + "__" + attr;
     * }, 0, function (value) {
     *     return value.toUpperCase();
     * });
     *
     * // Now markup is:
     * // <div id="one" aria-label="ONE__0__TEST"></div>
     */
    set: function (element, name, value, index, convert) {

        var prop = handlers[HANDLER_PROPERTY].parse(name);
        var hook = $.ariaHooks[prop.stem];

        if (isElement(element)) {

            if ($.isFunction(value)) {

                value = value.call(
                    element,
                    index,
                    element.getAttribute(prop.full)
                );

            }

            if (!$.isFunction(convert)) {
                convert = identity;
            }

            if (value !== undefined && value !== null) {

                if (hook && hook.set) {
                    value = hook.set(element, value, prop.full);
                }

                value = convert(value);

                if (value !== undefined && value !== null) {
                    element.setAttribute(prop.full, interpretString(value));
                }

            }

        }

    },

    /**
     * Checks to see if the given <code>name</code> exists on the given
     * <code>element</code>. The <code>name</code> is always normalised (see
     * [jQuery.normaliseAria]{@link external:jQuery.normaliseAria}) and if
     * <code>element</code> is not an element (see {@link isElement}) then
     * <code>false</code> will always be returned.
     *
     * @private
     * @param   {Element} element
     *          Element to test.
     * @param   {String}  name
     *          WAI-ARIA property to check.
     * @return  {Boolean}
     *          Whether or not the element has the given property.
     *
     * @example
     * // Markup is:
     * // <div id="one" aria-label="test"></div>
     *
     * var element = document.getElementById("one");
     * handlers.property.has(element, "label"); // -> true
     * handlers.property.has(element, "busy");  // -> false
     */
    has: function (element, name) {

        var prop = handlers[HANDLER_PROPERTY].parse(name);
        var hook = $.ariaHooks[prop.stem];

        return isElement(element)
            ? (hook && hook.has)
                ? hook.has(element, prop.full)
                : element.hasAttribute(prop.full)
            : false;

    },

    /**
     * Gets the value of the WAI-ARIA property from the given
     * <code>element</code> and returns it unchanged. The <code>name</code> is
     * normalised (see
     * [jQuery.normaliseAria]{@link external:jQuery.normaliseAria}). If
     * <code>element</code> is not an element (see {@link isElement}) or
     * <code>name</code> is not recognised (see
     * {@link handlers.property.has}) then <code>undefined</code> is returned.
     *
     * @private
     * @param   {Element}          element
     *          Element to access.
     * @param   {String}           name
     *          WAI-ARIA property to access.
     * @return  {String|undefined}
     *          WAI-ARIA attribute or undefined if the attribute isn't set.
     *
     * @example
     * // Markup is:
     * // <div id="one" aria-label="test"></div>
     *
     * var element = document.getElementById("one");
     * handlers.property.get(element, "label"); // -> "test"
     * handlers.property.get(element, "busy"); // -> undefined
     */
    get: function (element, name) {

        var handler = handlers[HANDLER_PROPERTY];
        var prop = handler.parse(name);
        var hook = $.ariaHooks[prop.stem];
        var response = handler.has(element, name)
            ? (hook && hook.get)
                ? hook.get(element, prop.full)
                : element.getAttribute(prop.full)
            : undefined;

        // getAttribute can return null, normalise to undefined.
        return response === null
            ? undefined
            : response;

    },

    /**
     * Removes a WAI-ARIA attribute from the given <code>element</code>. The
     * <code>name</code> if normalised (see
     * [jQuery.normaliseAria]{@link external:jQuery.normaliseAria}) and if
     * <code>element</code> is not an element (see {@link isElement}) then no
     * action is taken.
     *
     * @private
     * @param   {Element} element
     *          Element to modify.
     * @param   {String}  name
     *          WAI-ARIA attribute to remove.
     *
     * @example
     * // Markup is:
     * // <div id="one" aria-label="test"></div>
     *
     * var element = document.getElementById("one");
     * handlers.property.unset(element, "label");
     *
     * // Now markup is:
     * // <div id="one"></div>
     */
    unset: function (element, name) {

        var prop = handlers[HANDLER_PROPERTY].parse(name);
        var hook = $.ariaHooks[prop.stem];

        if (isElement(element)) {

            if (!hook || !hook.unset || hook.unset(element, prop.full)) {
                element.removeAttribute(prop.full);
            }

        }

    }

};

// Source: /src/global/handlers/reference.js


/**
 * Handles modifying WAI-ARIA references. Unlike {@link handlers.property}, this
 * will create references to elements and return them. The only defined methods
 * are:
 * <br>{@link handlers.reference.set} sets a reference.
 * <br>{@link handlers.reference.get} gets a reference.
 *
 * @alias     reference
 * @memberof  handlers
 * @namespace
 * @private
 */
handlers[HANDLER_REFERENCE] = {

    /**
     * Adds the WAI-ARIA reference to <code>element</code>. This differs from
     * {@link handlers.property.set} in that <code>reference</code> is passed
     * through [jQuery's $ function]{@link http://api.jquery.com/jquery/} and
     * identified (see [jQuery#identify]{@link external:jQuery#identify}) with
     * the ID of the first match being used. There is also no
     * <code>convert</code> parameter.
     * <br><br>
     * The <code>name</code> is still normalised (see
     * [jQuery.normaliseAria]{@link external:jQuery.normaliseAria}). If
     * <code>element</code> is not an element (see {@link isElement}) then no
     * action is taken.
     *
     * @private
     * @param   {Element}      element
     *          Element to modify.
     * @param   {String}       name
     *          WAI-ARIA attribute to set.
     * @param   {jQuery_param} reference
     *          Element to reference.
     * @param   {Number}       index
     *          Index of <code>element</code> within the collection.
     *
     * @example
     * // Markup is:
     * // <div class="one"></div>
     * // <div class="two"></div>
     *
     * var element = document.querySelector(".one");
     * handlers.reference.set(element, "labelledby", ".two");
     *
     * // Now markup is:
     * // <div class="one" aria=labelledby="anonymous0"></div>
     * // <div class="two" id="anonymous0"></div>
     */
    set: function (element, name, reference, index) {

        handlers[HANDLER_PROPERTY].set(
            element,
            name,
            reference,
            index,
            identify
        );

    },

    /**
     * Gets the reference from the given <code>element</code> and returns it as
     * a <code>jQuery</code> object. This differs from
     * {@link handlers.property.get} in that the match is assumed to be an ID
     * and a DOM lookup is done based upon that. The <code>name</code> is still
     * normalised (see
     * [jQuery.normaliseAria]{@link external:jQuery.normaliseAria}). If the
     * WAI-ARIA attribute is not found (see {@link handlers.property.has} then
     * <code>undefined</code> is returned.
     *
     * @private
     * @param   {Element}          element
     *          Element to check.
     * @param   {String}           name
     *          WAI-ARIA reference.
     * @return  {jQuery|undefined}
     *          jQuery object representing the reference or undefined if the
     *          attribute isn't set.
     *
     * @example
     * // Markup is:
     * // <div id="one" aria=labelledby="two"></div>
     * // <div id="two"></div>
     *
     * var element = document.getElementById("one");
     * handlers.reference.get(element, "labelledby");
     * // -> $(<div id="two">)
     * handlers.reference.get(element, "controls");
     * // -> undefined
     */
    get: function (element, name) {

        var handler = handlers[HANDLER_PROPERTY];

        return handler.has(element, name)
            ? $("#" + handler.get(element, name))
            : undefined;

    }

};

// Source: /src/global/handlers/state.js


var REGEXP_BOOLEAN = /^(?:true|false)$/;
var VALUE_MIXED = "mixed";

/**
 * Handles WAI-ARIA states. This differs from {@link handlers.property} in that
 * values are coerced into booleans before being set and a boolean (or the
 * string "mixed") will be returned.
 * <br>{@link handlers.state.read} converts the value into a boolean.
 * <br>{@link handlers.state.set} sets the state.
 * <br>{@link handlers.state.get} gets the state.
 *
 * @alias     state
 * @memberof  handlers
 * @namespace
 * @private
 */
handlers[HANDLER_STATE] = {

    /**
     * Reads the raw value and converts it into a boolean or the string
     * <code>"mixed"</code> (always lower case). If <code>raw</code> cannot be
     * correctly converted, it is assumed to be <code>true</code>.
     *
     * @private
     * @param   {?} raw
     *          Value to read.
     * @return  {Boolean|String}
     *          Converted value.
     *
     * @example <caption>Converting values</caption>
     * handlers.state.read(true);    // -> true
     * handlers.state.read("false"); // -> false
     * handlers.state.read("1");     // -> true
     * handlers.state.read(0);       // -> false
     * handlers.state.read("mixed"); // -> "mixed"
     *
     * @example <caption>Unrecognised values default to true</caption>
     * handlers.state.read("2");      // -> true
     * handlers.state.read(-1);       // -> true
     * handlers.state.read([]);       // -> true
     * handlers.state.read("mixed."); // -> true
     */
    read: function readState(raw) {

        var state = true;

        switch (typeof raw) {

        case "boolean":

            state = raw;
            break;

        case "string":

            raw = raw.toLowerCase();

            if (raw === VALUE_MIXED) {
                state = raw;
            } else if (raw === "1" || raw === "0") {
                state = readState(+raw);
            } else if (REGEXP_BOOLEAN.test(raw)) {
                state = raw === "true";
            }

            break;

        case "number":

            if (raw === 0 || raw === 1) {
                state = !!raw;
            }

            break;

        }

        return state;

    },

    /**
     * Sets the WAI-ARIA state defined in <code>name</code> on the given
     * <code>element</code>. This differs from {@link handlers.property.set} in
     * that <code>state</code> is converted into a boolean or
     * <code>"mixed"</code> before being assigned (see
     * {@link handlers.state.read}) and there is no <code>convert</code>
     * paramter. The <code>name</code> is still normalised (see
     * [jQuery.normaliseAria]{@link external:jQuery.normaliseAria}).
     *
     * @private
     * @param   {Element} element
     *          Element to modify.
     * @param   {String}  name
     *          WAI-ARIA attribute to set.
     * @param   {?}       state
     *          State to set.
     * @param   {Number}  index
     *          Index of <code>element</code> within the collection.
     *
     * @example
     * // Markup is:
     * // <div id="one"></div>
     * // <div id="two"></div>
     *
     * var one = document.getElementById("one");
     * var two = document.getElementById("two");
     * handlers.state.set(one, "busy", true);
     * handlers.state.set(two, "checked", "mixed");
     *
     * // Now markup is:
     * // <div id="one" aria-busy="true"></div>
     * // <div id="two" aria-checked="mixed"></div>
     */
    set: function (element, name, state, index) {

        handlers[HANDLER_PROPERTY].set(
            element,
            name,
            state,
            index,
            handlers[HANDLER_STATE].read
        );

    },

    /**
     * Reads the WAI-ARIA state on <code>element</code>. This differs from
     * {@link handlers.property.get} in that the result is converted into a
     * boolean or the strign `"mixed"` before being returned. The
     * <code>name</code> is still normalised (see {@link jQuery.normaliseAria}).
     *
     * @private
     * @param   {Element}    element
     *          Element to access.
     * @param   {String}     name
     *          WAI-ARIA state to read.
     * @return  {ARIA_state}
     *          State of the WAI-ARIA property.
     *
     * @example
     * // Markup is:
     * // <div id="one" aria-busy="true" aria-checked="mixed"></div>
     *
     * var element = document.getElementById("one");
     * handlers.state.get(element, "busy");     // -> true
     * handlers.state.get(element, "checked");  // -> "mixed"
     * handlers.state.get(element, "disabled"); // -> undefined
     */
    get: function (element, name) {

        var handler = handlers[HANDLER_PROPERTY];
        var state;
        var value;

        if (handler.has(element, name)) {

            value = handler.get(element, name).toLowerCase();
            state = value === VALUE_MIXED
                ? value
                : (REGEXP_BOOLEAN.test(value) && value === "true");

        }

        return state;

    }

};

// Source: /src/global/access.js


/**
 * This function handles all the heavy lifting of getting or setting WAI-ARIA
 * attributes. It is designed to be all that's necessary for
 * [jQuery#aria]{@link external:jQuery#aria},
 * [jQuery#ariaRef]{@link external:jQuery#ariaRef} and
 * [jQuery#ariaState]{@link external:jQuery#ariaState}. This function will check
 * its arguments to determine whether it should be used as a getter or a setter
 * and passes the appropriate arguments to the {@link handlers} methods based on
 * <code>type</code> (which will default to {@link handlers.property} if
 * ommitted or not recognised).
 * <br><br>
 * The return value is based on the type of action being performed. If this
 * function is setting then a jQuery object of the matches is returned (which is
 * almost always <code>jQelements</code>); if the function is a getter then the
 * results are returned for the first element in <code>jQelements</code>.
 * <br><br>
 * Although this description is not especially extensive, the code should be
 * very easy to follow and commented should there be any need to modify it. Once
 * the correct arguments are being passed to the appropriate {@link handlers}
 * method, they will take care of the rest.
 *
 * @global
 * @private
 * @param   {jQuery}            jQelements
 *          jQuery object to modify/access.
 * @param   {Object|String}     property
 *          Either WAI-ARIA names and values or the WAI-ARIA property name.
 * @param   {?}                 [value]
 *          Value to set.
 * @param   {String}            [type="property"]
 *          Optional attribute type.
 * @return  {jQuery|ARIA_state}
 *          Either the jQuery object on which WAI-ARIA properties were set or
 *          the values of the WAI-ARIA properties.
 *
 * @example <caption>Setting a single property</caption>
 * // Markup is
 * // <div id="one"></div>
 *
 * var jQone = $("#one");
 * access(jQone, "controls", "two"); // -> jQuery(<div id="one">)
 *
 * // Now markup is
 * // <div id="one" aria-controls="two">
 *
 * @example <caption>Setting multiple references</caption>
 * // Markup is
 * // <div id="one"></div>
 * // <div id="two"></div>
 *
 * var jQone = $("#one");
 * access(jQone, {
 *     controls: $("div").eq(1)
 * }, "reference"); // -> jQuery(<div id="one">)
 *
 * // Now markup is
 * // <div id="one" aria-controls="two">
 * // <div id="two"></div>
 *
 * @example <caption>Getting a state</caption>
 * // Markup is
 * // <div id="one" aria-busy="true"></div>
 *
 * var jQone = $("#one");
 * access(jQone, "busy", undefined, "state"); // -> true
 */
function access(jQelements, property, value, type) {

    var tempProperty = property;
    var isPropertyObject = $.isPlainObject(property);
    var isGet = value === undefined && !isPropertyObject;

    // Make sure the property value is in the expected format: an object for
    // setting and a string for getting.
    if (!isGet && !isPropertyObject) {

        property = {};
        property[tempProperty] = value;

    }

    // If we don't have or don't recognise the type, default to "property".
    if (!type || !handlers[type]) {
        type = HANDLER_PROPERTY;
    }

    return isGet
        ? handlers[type].get(jQelements[0], property)
        : jQelements.each(function (index, element) {

            $.each(property, function (key, val) {
                handlers[type].set(element, key, val, index);
            });

        });

}

// Source: /src/global/removeAttribute.js



/**
 * Removes the named WAI-ARIA attribute from all elements in the current
 * collection. The <code>name</code> is normalised (see
 * [jQuery.normaliseAria]{@link external:jQuery.normaliseAria}). This function
 * is aliased as [jQuery#removeAriaRef]{@link external:jQuery#removeAriaRef} and
 * [jQuery#removeAriaState]{@link external:jQuery#removeAriaState}.
 *
 * @alias    removeAria
 * @memberof external:jQuery
 * @instance
 * @param    {String} name
 *           WAI-ARIA attribute to remove.
 * @return   {jQuery}
 *           jQuery attribute representing the elements modified.
 *
 * @example
 * // Markup is
 * // <div id="one" aria-busy="true"></div>
 *
 * $("#one").removeAria("busy"); // -> jQuery(<div id="one">)
 *
 * // Now markup is:
 * // <div id="one"></div>
 */
function removeAttribute(name) {

    return this.each(function (ignore, element) {
        handlers[HANDLER_PROPERTY].unset(element, name);
    });

}

// Source: /src/member/normaliseAria.js


/**
 * Alias of [jQuery.normaliseAria]{@link external:jQuery.normaliseAria}
 *
 * @function
 * @alias    external:jQuery.normalizeAria
 * @memberof external:jQuery
 * @param    {String} name
 *           Attribute name to normalise.
 * @return   {String}
 *           Normalised attribute name.
 * @property {Object.<String>} cache
 *           The cache of requests to responses.
 */
$.normalizeAria = normalise;
$.normaliseAria = normalise;

// Source: /src/member/ariaFix.js


/**
 * A map of unprefixed WAI-ARIA attributes that should be converted before being
 * normalised (see [jQuery.normaliseAria]{@link external:jQuery.normaliseAria}).
 *
 * @alias    external:jQuery.ariaFix
 * @memberof external:jQuery
 * @type     {Object.<String>}
 *
 * @example <caption>Correcting a common typo</caption>
 * $.ariaFix.budy = "busy";
 * $.normaliseAria("budy");      // -> "aria-busy"
 * $.normaliseAria("aria-budy"); // -> "aria-busy"
 */
$.ariaFix = {

    // This is the US English spelling but the ccessibility API defined the
    // attribute with the double L.
    // https://www.w3.org/TR/wai-aria/states_and_properties#aria-labelledby
    labeledby: "labelledby"

};

// If Proxy is available, we can use it to check whenever $.ariaFix is modified
// and invalidate the cache of normalise() when it is. This is a lot more
// efficient than always converting $.ariaFix to a JSON string to ensure the
// cache is accurate.
if (IS_PROXY_AVAILABLE) {

    $.ariaFix = new Proxy($.ariaFix, {

        set: function (target, name, value) {

            normalise.cache = {};
            target[name] = value;

        }

    });

}

// Source: /src/member/ariaHooks.js


/**
 * A collection of hooks that change the behaviour of attributes being set,
 * retrieved, checked or removed (called [set]{@link ARIA_hook_set},
 * [get]{@link ARIA_hook_get}, [has]{@link ARIA_hook_has},
 * [unset]{@link ARIA_hook_unset} - see {@link ARIA_hook} for full details). The
 * name of the hook is always the un-prefixed WAI-ARIA attribute in lower case
 * after any mapping has occurred (see
 * [jQuery.ariaFix]{@link external:jQuery.ariaFix}). If you are ever in doubt,
 * the easiest way to know the key is to slice the normalised value:
 * <code>$.normaliseAria(__WAI-ARIA_ATTRIBUTE__).slice(5)</code> (see
 * [jQuery.normaliseAria]{@link external:jQuery.normaliseAria} for more
 * information).
 * <br><br>
 * Do not use these functions to set different WAI-ARIA attributes without
 * setting the one being passed to the aria method; for example: do not create a
 * set for "attribute1" that sets "attribute2" instead - unless you add the same
 * conversion to <code>has</code>, <code>get</code> will not be triggered.
 * Instead, use [jQuery.ariaFix]{@link external:jQuery.ariaFix} to convert the
 * attribute name.
 * <br><br>
 * [jQuery#aria]{@link external:jQuery#aria},
 * [jQuery#ariaRef]{@link external:jQuery#ariaRef},
 * [jQuery#ariaState]{@link external:jQuery#ariaState},
 * [jQuery#removeAria]{@link external:jQuery#removeAria},
 * [jQuery#removeAriaRef]{@link external:jQuery#removeAriaRef} and
 * [jQuery#removeAriaState]{@link external:jQuery#removeAriaState} all run
 * through these hooks (if they exist) and these hooks replace the functionality
 * of manipulating or checking the attributes after any conversion process has
 * occurred within the method itself.
 *
 * @alias    external:jQuery.ariaHooks
 * @memberof external:jQuery
 * @type     {Object.<ARIA_hook>}
 *
 * @example
 * // aria-level should be an integer greater than or equal to 1 so the getter
 * // should return an integer.
 * $.ariaHooks.level = {
 *     set: function (element, value) {
 *         var intVal = Math.max(1, Math.floor(value));
 *         if (!isNaN(intVal)) {
 *             element.setAttribute("aria-level", intVal)
 *         }
 *     },
 *     get: function (element) {
 *         var value = element.getAttribute("aria-level");
 *         var intVal = (Math.max(1, Math.floor(value));
 *         return (value === null || isNaN(intVal))
 *             ? undefined
 *             : intVal;
 *     }
 * };
 */
$.ariaHooks = {

    hidden: {

        // Setting aria-hidden="false" is considered valid, but removing the
        // aria-hidden attribute has the same effect and I think it's tidier.
        // https://www.w3.org/TR/wai-aria/states_and_properties#aria-hidden
        set: function (element, value, name) {

            var response;

            if (value === false || +value === 0 || (/^false$/i).test(value)) {
                element.removeAttribute(name);
            } else {
                response = value;
            }

            return response;

        }

    }

};

// Source: /src/instance/identify.js



var count = 0;

/**
 * Identifies the first element in the collection by getting its ID. If the
 * element doesn't have an ID attribute, a unique on is generated and assigned
 * before being returned. If the collection does not have a first element then
 * <code>undefined</code> is returned.
 * <br><br>
 * IDs are a concatenation of "anonymous" and a hidden counter that is increased
 * each time. If the ID already exists on the page, that ID is skipped and not
 * assigned to a second element.
 *
 * @memberof external:jQuery
 * @instance
 * @alias    identify
 * @return   {String|undefined}
 *           The ID of the first element or undefined if there is no first
 *           element.
 *
 * @example <caption>Identifying elements</caption>
 * // Markup is
 * // <div class="one"></div>
 * // <span class="one"></span>
 *
 * $(".one").identify(); // -> "anonymous0"
 *
 * // Now markup is:
 * // <div class="one" id="anonymous0"></div>
 * // <span class="one"></span>
 * // Running $(".one").identify(); again would not change the markup.
 *
 * @example <caption>Existing IDs are not duplicated</caption>
 * // Markup is:
 * // <div class="two" id="anonymous1"><!-- manually set --></div>
 * // <div class="two"></div>
 * // <div class="two"></div>
 *
 * $(".two").each(function () {
 *     $(this).identify();
 * });
 *
 * // Now markup is:
 * // <div class="two" id="anonymous1"><!-- manually set --></div>
 * // <div class="two" id="anonymous0"></div>
 * // <div class="two" id="anonymous2"></div>
 */
$.fn.identify = function () {

    var element = this[0];
    var isAnElement = isElement(element);
    var id = isAnElement
        ? element.id
        : undefined;

    if (isAnElement && !id) {

        do {

            id = "anonymous" + count;
            count += 1;

        } while (document.getElementById(id));

        element.id = id;

    }

    return id;

};

// Source: /src/instance/aria.js



/**
 * Gets or sets WAI-ARIA properties. The properties will not be modified any
 * more than they need to be (unlike
 * [jQuery#ariaRef]{@link external:jQuery#ariaRef} or
 * [jQuery#ariaState]{@link external:jQuery#ariaState} which will interpret the
 * values).
 * <br><br>
 * To set WAI-ARIA properties, pass either a
 * <code>property</code>/<code>value</code> pair of arguments or an object
 * containing those pairs. When this is done, the attributes are set on all
 * elements in the collection and the <code>jQuery</code> object is returned to
 * allow for chaining. If <code>value</code> is a function and returns
 * <code>undefined</code> (or nothing) then no action is taken for that element.
 * This can be useful for selectively setting values only when certain criteria
 * are met.
 * <br><br>
 * To get WAI-ARIA properties, only pass the <code>property</code> that you want
 * to get. If there is no matching property, <code>undefined</code> is returned.
 * All properties are normalised (see
 * [jQuery.normaliseAria]{@link external:jQuery.normaliseAria}).
 *
 * @memberof external:jQuery
 * @instance
 * @alias    aria
 * @param    {Object|String} property
 *           Either the properties to set in key/value pairs or the name of the
 *           property to get/set.
 * @param    {Attribute_Callback|Boolean|Number|String} [value]
 *           The value of the property to set.
 * @return   {jQuery|String|undefined}
 *           Either the jQuery object (after setting) or a string or undefined
 *           (after getting)
 *
 * @example <caption>Setting WAI-ARIA attribute(s)</caption>
 * $("#element").aria("aria-label", "test");
 * // or
 * $("#element").aria("label", "test");
 * // or
 * $("#element").aria({
 *     "aria-label": "test"
 * });
 * // or
 * $("#element").aria({
 *     label: "test"
 * });
 * // All of these set aria-label="test" on all matching elements and return a
 * // jQuery object representing "#element"
 *
 * @example <caption>Setting WAI-ARIA attribute(s) with a function</caption>
 * $("#element").aria("label", function (i, attr) {
 *     return this.id + "__" + i + "__" + attr;
 * });
 * // or
 * $("#element").aria({
 *     label: function (i, attr) {
 *         return this.id + "__" + i + "__" + attr;
 *     }
 * });
 * // Both of these set aria-label="element__0__undefined" on all matching
 * // elements and return a jQuery object representing "#element"
 *
 * @example <caption>Getting a WAI-ARIA attribute</caption>
 * // Markup is:
 * // <div id="element" aria-label="test"></div>
 * $("#element").aria("label");   // -> "test"
 * $("#element").aria("checked"); // -> undefined
 * // If "#element" matches multiple elements, the attributes from the first
 * // element are returned.
 *
 * @example <caption>Setting with aria methods</caption>
 * // Markup is:
 * // <div class="one"></div>
 * // <div class="two"></div>
 * // <div class="three"</div>
 *
 * var settings = {
 *     busy: 0,
 *     controls: ".one",
 *     label: "lorem ipsum"
 * };
 *
 * $(".one").aria(settings);
 * $(".two").ariaRef(settings);
 * $(".three").ariaState(settings);
 *
 * // Now markup is:
 * // <div class="one"
 * //     aria-busy="0"
 * //     aria-controls=".one"
 * //     aria-label="lorem ipsum"
 * //     id="anonymous0"></div>
 * // <div class="two"
 * //     aria-controls="anonymous0"></div>
 * // <div class="three"
 * //     aria-busy="false"
 * //     aria-controls="true"
 * //     aria-label="true"></div>
 *
 * @example <caption>Getting with aria methods</caption>
 * // Markup is:
 * // <div id="test" aria-flowto="false"></div>
 * // <div id="false"></div>
 *
 * $("#test").aria("flowto");      // -> "false"
 * $("#test").ariaRef("flowto");   // -> jQuery(<div id="false">)
 * $("#test").ariaState("flowto"); // -> false
 */
$.fn.aria = function (property, value) {

    return access(
        this,
        property,
        value
    );

};

// Source: /src/instance/ariaRef.js



/**
 * Gets or sets a WAI-ARIA reference. This is functionally identical to
 * [jQuery#aria]{@link external:jQuery#aria} with the main difference being that
 * an element may be passed as the <code>value</code> when setting and that a
 * jQuery object is returned when getting.
 * <br><br>
 * Because WAI-ARIA references work with IDs, IDs are worked out using
 * [jQuery#identify]{@link external:jQuery#identify}. Be aware that any string
 * passed to [jQuery#ariaRef]{@link external:jQuery#ariaRef} will be treated
 * like a CSS selector and looked up with the results being used to set the
 * property. If you already have the ID and wish to set it without the lookup,
 * use [jQuery#aria]{@link external:jQuery#aria}.
 * <br><br>
 * If <code>value</code> is a function then the resulting value is identified.
 * This can be particularly useful for performing DOM traversal to find the
 * reference (see examples below). As with
 * [jQuery#aria]{@link external:jQuery#aria}, if the <code>value</code> function
 * returns nothing or returns <code>undefined</code> then no action is taken.
 * <br><br>
 * When accessing the attribute using this function, a <code>jQuery</code>
 * object representing the reference is returned. If there are multiple elements
 * in the collection, only the reference for the first element is returned. To
 * get the value of the attribute rather than the element, use
 * [jQuery#aria]{@link external:jQuery#aria}.
 *
 * @memberof external:jQuery
 * @instance
 * @alias    ariaRef
 * @param    {Object|String} property
 *           Either the properties to set in key/value pairs or the name of the
 *           property to set.
 * @param    {Attribute_Callback|jQuery_param} [value]
 *           Reference to set.
 * @return   {jQuery}
 *           jQuery object representing either the elements that were modified
 *           (when setting) or the referenced element(s) (when getting - may be
 *           an empty jQuery object).
 *
 * @example <caption>Setting references</caption>
 * // Markup is:
 * // <h1>Heading</h1>
 * // <div class="one">
 * //     Lorem ipsum dolor sit amet ...
 * // </div>
 *
 * $(".one").ariaRef("labelledby", $("h1"));
 * // or
 * $(".one").ariaRef("labelledby", "h1");
 * // or
 * $(".one").ariaRef("labelledby", $("h1")[0]);
 * // or
 * $(".one").ariaRef({
 *     labelledby: $("h1") // or "h1" or $("h1")[0]
 * });
 * // Each of these return a jQuery object representing ".one"
 *
 * // Now markup is:
 * // <h1 id="anonymous0">Heading</h1>
 * // <div class="one" aria-labelledby="anonymous0">
 * //     Lorem ipsum dolor sit amet ...
 * // </div>
 *
 * @example <caption>Setting references with a function</caption>
 * // Markup is:
 * // <div class="js-collapse">
 * //     <div class="js-collapse-content">
 * //         Lorem ipsum dolor sit amet ...
 * //     </div>
 * //     <button class="js-collapse-toggle">
 * //         Toggle
 * //     </button>
 * // </div>
 *
 * $(".js-collapse-toggle").ariaRef("controls", function (i, attr) {
 *
 *     return $(this)
 *         .closest(".js-collapse")
 *         .find(".js-collapse-content");
 *
 * });
 *
 * // Now markup is:
 * // <div class="js-collapse">
 * //     <div class="js-collapse-content" id="anonymous0">
 * //         Lorem ipsum dolor sit amet ...
 * //     </div>
 * //     <button class="js-collapse-toggle" aria-controls="anonymous0">
 * //         Toggle
 * //     </button>
 * // </div>
 *
 * @example <caption>Getting a reference</caption>
 * // Markup is:
 * // <h1 id="anonymous0">Heading</h1>
 * // <div class="one" aria-labelledby="anonymous0">
 * //     Lorem ipsum dolor sit amet ...
 * // </div>
 *
 * $(".one").ariaRef("labelledby"); // -> $(<h1>)
 * $(".one").ariaRef("controls");   // -> $()
 *
 * @example <caption>Value is treated like a CSS selector</caption>
 * // Markup is:
 * // <button id="button"></button>
 * // <div id="section"></div>
 * // <section></section>
 *
 * $("#button").ariaRef("controls", "section");
 *
 * // Now markup is:
 * // <button id="button" aria-controls="anonymous0"></button>
 * // <div id="section"></div>
 * // <section id="anonymous0"></section>
 */
$.fn.ariaRef = function (property, value) {

    return access(
        this,
        property,
        value,
        HANDLER_REFERENCE
    );

};

// Source: /src/instance/ariaState.js



/**
 * Sets or gets the WAI-ARIA state of the collection.
 * <br><br>
 * When setting the state, false, "false" (any case), 0 and "0" will be
 * considered false. All other values will be considered true except for "mixed"
 * (any case) which will set the state to "mixed". The differs from
 * [jQuery#aria]{@link external:jQuery#aria} which will simply set the
 * attribute(s) without converting the value.
 * <br><br>
 * After setting the state(s), a jQuery object representing the affected
 * elements is returned. The state for the first matching element is returned
 * when getting.
 * <br><br>
 * All attributes are normalised - see
 * [jQuery.normaliseAria]{@link external:jQuery.normaliseAria} for full details.
 *
 * @memberof external:jQuery
 * @instance
 * @alias    ariaState
 * @param    {Object|String} property
 *           Either a key/value combination properties to set or the name of the
 *           WAI-ARIA state to set.
 * @param    {Attribute_Callback|Boolean|Number|String} [value]
 *           Value of the attribute.
 * @return   {ARIA_state|jQuery}
 *           Either the jQuery object representing the modified elements
 *           (setting) or the state of the first matching element.
 *
 * @example <caption>Getting state</caption>
 * // Markup is:
 * // <div id="one" aria-busy="true" aria-checked="mixed"></div>
 *
 * $("#one").ariaState("busy");    // -> true
 * $("#one").ariaState("checked"); // -> "mixed"
 * $("#one").ariaState("hidden");  // -> undefined
 *
 * @example <caption>Setting state</caption>
 * // Each of these will set the state to false:
 * $("#one").ariaState("busy", "false");
 * $("#one").ariaState("busy", "FALSE");
 * $("#one").ariaState("busy", false);
 * $("#one").ariaState("busy", 0);
 * $("#one").ariaState("busy", "0");
 *
 * // Each of these will set the state to "mixed":
 * $("#one").ariaState("checked", "mixed");
 * $("#one").ariaState("checked", "MIXED");
 *
 * // Each of these will set the state to true
 * $("#one").ariaState("busy", "true");
 * $("#one").ariaState("busy", "TRUE");
 * $("#one").ariaState("busy", true);
 * $("#one").ariaState("busy", 1);
 * $("#one").ariaState("busy", "1");
 * // WARNING: these also set the state to true
 * $("#one").ariaState("busy", {});
 * $("#one").ariaState("busy", null);
 * $("#one").ariaState("busy", "nothing");
 * $("#one").ariaState("busy", "");
 * $("#one").ariaState("busy", -1);
 *
 * // Each example returns a jQuery object representing "#one" and an object
 * // can be passed as parameters as well:
 * $("#one").ariaState({
 *     busy: true
 * });
 *
 * @example <caption>Setting state with a function</caption>
 * // Markup is:
 * // <div class="checkbox"></div>
 * // <input type="checkbox" checked>
 *
 * $(".checkbox").ariaState("checked", function (i, attr) {
 *
 *     return $(this)
 *         .next("input[type=\"checkbox\"]")
 *         .prop("checked");
 *
 * });
 *
 * // Now markup is:
 * // <div class="checkbox" aria-checked="true"></div>
 * // <input type="checkbox" checked>
 */
$.fn.ariaState = function (property, value) {

    return access(
        this,
        property,
        value,
        HANDLER_STATE
    );

};

// Source: /src/instance/removeAria.js


$.fn.extend({

    removeAria: removeAttribute,

    /**
     * Alias of [jQuery#removeAria]{@link external:jQuery#removeAria}.
     *
     * @memberof external:jQuery
     * @instance
     * @function
     * @param    {String} name
     *           WAI-ARIA attribute to remove.
     * @return   {jQuery}
     *           jQuery attribute representing the elements modified.
     */
    removeAriaRef: removeAttribute,

    /**
     * Alias of [jQuery#removeAria]{@link external:jQuery#removeAria}.
     *
     * @memberof external:jQuery
     * @instance
     * @function
     * @param    {String} name
     *           WAI-ARIA attribute to remove.
     * @return   {jQuery}
     *           jQuery attribute representing the elements modified.
     */
    removeAriaState: removeAttribute

});

// Source: /src/instance/role.js



/**
 * Sets the role of all elements in the collection or gets the role of the first
 * element in the collection, depending on whether or not the <code>role</code>
 * argument is provided. As [jQuery#role]{@link external:jQuery#role} is just a
 * wrapper for [jQuery#attr]{@link http://api.jquery.com/attr/}, the
 * <code>role</code> parameter can actually be any value type that the official
 * documentation mentions.
 * <br><br>
 * According to the WAI-ARIA specs, an element can have mutliple roles as a
 * space-separated list. This method will only set the role attribute to the
 * given string when setting. If you want to modify the roles, use
 * [jQuery#addRole]{@link external:jQuery#addRole} and
 * [jQuery#removeRole]{@link external:jQuery#removeRole}.
 *
 * @memberof external:jQuery
 * @instance
 * @alias    role
 * @param    {Attribute_Callback|String} [role]
 *           Role to get or function to set the role.
 * @return   {jQuery|String|undefined}
 *           Either the jQuery object representing the elements that were
 *           modified or the role value.
 *
 * @example
 * // Markup is:
 * // <div id="one"></div>
 * // <div id="two"></div>
 *
 * $("#one").role("presentation"); // -> jQuery(<div id="one">)
 *
 * // Now markup is:
 * // <div id="one" role="presentation"></div>
 * // <div id="two"></div>
 *
 * $("#one").role(); // -> "presentation"
 * $("#two").role(); // -> undefined
 *
 * @example <caption>Setting a role with a function</caption>
 * // Markup is:
 * // <div id="one" role="button"></div>
 *
 * $("#one").role(function (index, current) {
 *     return current + " tooltip";
 * });
 *
 * // Now markup is:
 * // <div id="one" role="button tooltip"></div>
 */
$.fn.role = function (role) {

    return role === undefined
        ? this.attr("role")
        : this.attr("role", role);

};

// Source: /src/instance/addRole.js



/**
 * Adds a role to a collection of elements. The role will not be added if it's
 * empty ("" or undefined), if the function response is empty or if the element
 * already has that role. In that way it's similar to
 * [jQuery#addClass]{@link https://api.jquery.com/addClass/}.
 *
 * @memberof external:jQuery
 * @instance
 * @alias    addRole
 * @param    {Attribute_Callback|String} role
 *           Role(s) to add to the matching elements or function to generate the
 *           role(s) to add.
 * @return   {jQuery}
 *           jQuery object representing the matching elements.
 *
 * @example <caption>Adding a role</caption>
 * // Markup is:
 * // <div class="one" role="presentation"></div>
 * // <div class="one"></div>
 *
 * $(".one").addRole("alert"); // -> jQuery(<div>, <div>)
 *
 * // Now markup is:
 * // <div class="one" role="presentation alert"></div>
 * // <div class="one" role="alert"></div>
 *
 * @example <caption>Adding a role with a function</caption>
 * // Markup is:
 * // <div class="one" role="presentation"></div>
 *
 * $(".one").addRole(function (index, current) {
 *     return "alert combobox";
 * });
 *
 * // Now markup is:
 * // <div class="one" role="presentation alert combobox"></div>
 */
$.fn.addRole = function (role) {

    var isFunction = $.isFunction(role);

    return this.role(function (index, current) {

        var value = isFunction
            ? role.call(this, index, current)
            : role;
        var roles = toWords(current);

        toWords(value).forEach(function (val) {

            if (
                val !== ""
                && val !== undefined
                && roles.indexOf(val) < 0
            ) {
                roles.push(val);
            }

        });

        return roles.join(" ");

    });

};

// Source: /src/instance/removeRole.js



/**
 * Removes roles from the collection of elements. If the method is called
 * without any arguments then the role attribute itself is removed. Be aware
 * that this is not the same as passing a function which returns undefined -
 * such an action will have no effect.
 *
 * @memberof external:jQuery
 * @instance
 * @alias    removeRole
 * @param    {Attribute_Callback|String} [role]
 *           Role(s) to remove or a function to generate the role(s) to remove.
 * @return   {jQuery}
 *           jQuery object representing the matched elements.
 *
 * @example <caption>Removing a role</caption>
 * // Markup is:
 * // <div class="one" role="presentation alert"></div>
 * // <div class="one" role="alert"></div>
 *
 * $(".one").removeRole("alert"); // -> jQuery(<div>, <div>)
 *
 * // Now markup is:
 * // <div class="one" role="presentation"></div>
 * // <div class="one" role=""></div>
 *
 * @example <caption>Completely removing a role</caption>
 * // Markup is:
 * // <div class="one" role="presentation alert"></div>
 * // <div class="one" role="alert"></div>
 *
 * $(".one").removeRole(); // -> jQuery(<div>, <div>)
 *
 * // Now markup is:
 * // <div class="one"></div>
 * // <div class="one"></div>
 *
 * @example <caption>Removing a role with a function</caption>
 * // Markup is:
 * // <div class="one" role="presentation alert combobox"></div>
 *
 * $(".one").removeRole(function (index, current) {
 *     return current
 *         .split(/\s+/)
 *         .filter(function (role) {
 *             return role.indexOf("a") > -1;
 *         })
 *         .join(" ");
 *     // "presentation alert"
 * });
 *
 * // Now markup is:
 * // <div class="one" role="combobox"></div>
 */
$.fn.removeRole = function (role) {

    var isFunction = $.isFunction(role);

    return role === undefined
        ? this.removeAttr("role")
        : this.role(function (index, current) {

            var value = isFunction
                ? role.call(this, index, current)
                : role;
            var values = toWords(value);

            return toWords(current)
                .filter(function (aRole) {
                    return values.indexOf(aRole) < 0;
                })
                .join(" ");

        });

};

// Source: /src/instance/ariaFocusable.js



/**
 * Sets whether or not the matching elements are focusable. Strings, numbers and
 * booleans are understood as <code>state</code> - see
 * [jQuery#ariaState]{@link external:jQuery#ariaState} for full details as the
 * algorythm is the same.
 * <br><br>
 * Be aware this this function will only modify the matching elements, it will
 * not check any parents or modify any other elements that could affect the
 * focusability of the element.
 *
 * @memberof external:jQuery
 * @instance
 * @alias    ariaFocusable
 * @param    {Attribute_Callback|Boolean|Number|String} state
 *           State to set.
 * @return   {jQuery}
 *           jQuery object representing the affected element(s).
 *
 * @example <caption>Setting focusability</caption>
 * // Markup is
 * // <div id="one"></div>
 * // <div id="two"></div>
 *
 * $("#one").ariaFocusable(false); // -> jQuery(<div id="one">)
 * $("#two").ariaFocusable(true);  // -> jQuery(<div id="two">)
 *
 * // Now markup is
 * // <div id="one" tabindex="0"></div>
 * // <div id="two" tabindex="-1"></div>
 *
 * @example <caption>Limitations of the function</caption>
 * // Markup is
 * // <div id="one" tabindex="-1">
 * //     <div id="two" disabled></div>
 * // </div>
 *
 * $("#two").ariaFocusable(true); // -> jQuery(<div id="two">)
 *
 * // Now markup is
 * // <div id="one" tabindex="-1">
 * //     <div id="two" disabled tabindex="0"></div>
 * // </div>
 */
$.fn.ariaFocusable = function (state) {

    return this.attr(
        "tabindex",
        handlers[HANDLER_STATE].read(state)
            ? 0
            : -1
    );

};

}(jQuery));