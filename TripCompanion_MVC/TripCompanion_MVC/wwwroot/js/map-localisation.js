
var map = L.map('TravelMap');

function ShowMap(lat, lon) {

    map.setView([lat,lon], 13);
    var marker = L.marker([lat, lon]).addTo(map);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        maxZoom: 19,
        attribution: '© OpenStreetMap'
    }).addTo(map);

};

