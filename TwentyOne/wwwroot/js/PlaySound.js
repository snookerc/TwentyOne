
window.PlaySound = (() => {
    let context = null;
    return async url => {
        if (context) context.close();
        context = new AudioContext();
        const source = context.createBufferSource();
        source.buffer = await fetch(url)
            .then(res => res.arrayBuffer())
            .then(arrayBuffer => context.decodeAudioData(arrayBuffer));
        source.connect(context.destination);
        source.start();
    };
})();

