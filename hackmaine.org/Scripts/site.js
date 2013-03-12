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

$(function () {
    if ($.fancybox) {
        // Default
        $(".fancybox").fancybox({
            type: 'image', openEffect: 'elastic', closeEffect: 'elastic', padding: '4',
            helpers: {
                title: { type: 'float' }
            }
        });
        $(".map").fancybox({
            maxWidth: 800,
            maxHeight: 600,
            fitToView: false,
            width: '70%',
            height: '70%',
            autoSize: false,
            closeClick: false,
            openEffect: 'none',
            closeEffect: 'none'
        });

    }
});

// Begin: Google Analytics
var _gaq = _gaq || [];
_gaq.push(['_setAccount', 'UA-39219252-1']);
_gaq.push(['_trackPageview']);

(function () {
    var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
    ga.src = ('https:' == document.location.protocol ? 'https://' : 'http://') + 'stats.g.doubleclick.net/dc.js';
    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
})();
// End: Google Analytics
