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
