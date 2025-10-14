(function() {
    'use strict';
    setTimeout(() => {
        

    //Email Address Only//
    var REGEX_EMAIL = '([a-z0-9!#$%&\'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&\'*+/=?^_`{|}~-]+)*@' + '(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)';

    var formatName = function(item) {
        return ((item.first || '') + ' ' + (item.last || '')).trim();
    };

    new TomSelect('#select-to',{
        persist: false,
        maxItems: null,
        valueField: 'email',
        labelField: 'name',
        searchField: ['first', 'last', 'email'],
        sortField: [
            {field: 'first', direction: 'asc'},
            {field: 'last', direction: 'asc'}
        ],
        options: [
            {email: 'nikola@tesla.com', first: 'Nikola', last: 'Tesla'},
            {email: 'brian@thirdroute.com', first: 'Brian', last: 'Reavis'},
            {email: 'someone@gmail.com'},
            {email: 'example@gmail.com'},
        ],
        render: {
            item: function(item, escape) {
                var name = formatName(item);
                return '<div>' +
                    (name ? '<span class="name">' + escape(name) + '</span>' : '') +
                    (item.email ? '<span class="email">' + escape(item.email) + '</span>' : '') +
                '</div>';
            },
            option: function(item, escape) {
                var name = formatName(item);
                var label = name || item.email;
                var caption = name ? item.email : null;
                return '<div>' +
                    '<span class="label">' + escape(label) + '</span>' +
                    (caption ? '<span class="caption">' + escape(caption) + '</span>' : '') +
                '</div>';
            }
        },
        createFilter: function(input) {
            var regexpA = new RegExp('^' + REGEX_EMAIL + '$', 'i');
            var regexpB = new RegExp('^([^<]*)\<' + REGEX_EMAIL + '\>$', 'i');
            return regexpA.test(input) || regexpB.test(input);
        },
        create: function(input) {
            if ((new RegExp('^' + REGEX_EMAIL + '$', 'i')).test(input)) {
                return {email: input};
            }
            var match = input.match(new RegExp('^([^<]*)\<' + REGEX_EMAIL + '\>$', 'i'));
            if (match) {
                var name       = match[1].trim();
                var pos_space  = name.indexOf(' ');
                var first = name.substring(0, pos_space);
                var last  = name.substring(pos_space + 1);

                return {
                    email: match[2],
                    first: first,
                    last: last
                };
            }
            alert('Invalid email address.');
            return false;
        }
    });
    //Email Address Only//


    //Single Select Option groups//
    new TomSelect('#Single-option-group',{
        optgroupField: 'class',
        searchField: ['name'],
    });
    //Single Select Option groups//

    //Multiple Select Option groups//
    new TomSelect('#Multiple-option-group',{
        optgroupField: 'class',
        searchField: ['name'],
    });
    //Multiple Select Option groups//


    //Data-* Attributes//
    new TomSelect('#data-attr',{
        render: {
            option: function (data, escape) {
                return `<div><img class="mud-avatar mud-avatar-xs me-2" src="${data.src}">${data.text}</div>`;
            },
            item: function (item, escape) {
                return `<div><img class="mud-avatar mud-avatar-xs me-2" src="${item.src}">${item.text}</div>`;
            }
        }
    });
    //Data-* Attributes//

    }, 100);

})();

