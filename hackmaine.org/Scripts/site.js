var hackmaine = {
    Sounds: {
        PlayYes: function () {
            try {
                var snd = new Audio("/Audio/beep-3.wav");
                snd.play();
            }
            catch (ex) { }
        },
        PlayNo: function () {
            try {
                var snd = new Audio("/Audio/beep-4.wav");
                snd.play();
            }
            catch (ex) { }
        }
    }
};

// Begin: Google Analytics
var _gaq = _gaq || [];
_gaq.push(['_setAccount', 'UA-4082072-8']);
_gaq.push(['_trackPageview']);

(function() {
    var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
    ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
})();
// End: Google Analytics
