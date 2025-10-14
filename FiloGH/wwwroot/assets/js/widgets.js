(function () {
    'use strict';

    // Users by country map
    var markers = [{
        name: 'Russia',
        coords: [61, 105],
        style: {
            fill: '#28d193'
        }
    },
    {
        name: 'Geenland',
        coords: [72, -42],
        style: {
            fill: '#ff8c33'
        }
    },
    {
        name: 'Canada',
        coords: [56, -106],
        style: {
            fill: '#ff534d'
        }
    },
    {
        name: 'Palestine',
        coords: [31.5, 34.8],
        style: {
            fill: '#ffbe14'
        }
    },
    {
        name: 'Brazil',
        coords: [-14.2350, -51.9253],
        style: {
            fill: '#4b9bfa'
        }
    },
    ];
    var map = new jsVectorMap({
        map: 'world_merc',
        selector: '#users-map',
        markersSelectable: true,

        onMarkerSelected(index, isSelected, selectedMarkers) {
            console.log(index, isSelected, selectedMarkers);
        },

        // -------- Labels --------
        labels: {
            markers: {
                render: function (marker) {
                    return marker.name
                },
            },
        },

        // -------- Marker and label style --------
        markers: markers,
        markerStyle: {
            hover: {
                stroke: "#DDD",
                strokeWidth: 3,
                fill: '#FFF'
            },
            selected: {
                fill: '#ff525d'
            }
        },
        markerLabelStyle: {
            initial: {
                fontFamily: 'Poppins',
                fontSize: 13,
                fontWeight: 500,
                fill: '#35373e',
            },
        },
    })

})();
