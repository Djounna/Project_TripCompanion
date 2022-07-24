
function ShowMap(lon, lat) {

var map = L.map('TravelMap').setView([lon,lat], 13);
var marker = L.marker([lon, lat]).addTo(map);

L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
    maxZoom: 19,
    attribution: '© OpenStreetMap'
}).addTo(map);

};