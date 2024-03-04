var RedirectionDict = {
    "Home" : "../index.html",
};

function redirect(page) {
    var url = RedirectionDict[page];
    if (url) {
        window.location.href=url;
}};