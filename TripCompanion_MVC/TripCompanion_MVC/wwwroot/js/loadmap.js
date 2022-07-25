function LoadMap(lat, lon) {

    map.setView([lat, lon], 5);
    var marker = L.marker([lat, lon]).addTo(map);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        maxZoom: 19,
        attribution: '© OpenStreetMap'
    }).addTo(map);

};