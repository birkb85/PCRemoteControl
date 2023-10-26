self.addEventListener('fetch', function (event) {
    event.respondWith(fetch(event.request));
});
//self.addEventListener('fetch', function () {
//    return;
//});