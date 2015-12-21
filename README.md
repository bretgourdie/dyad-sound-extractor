# dyad-sound-extractor
<a href="http://www.dyadgame.com">Dyad</a> is a pretty cool game. The sounds are rad, too, but they're all locked up!

After <a href="https://twitter.com/sssmcgrath/status/671548164927848448">some guidance from Shawn McGrath himself</a>, I wrote a little program to get the individual sound files of all SoundBin files.

dyad-sound-extractor extracts the packaged files from Dyad's SoundBin folder and writes them as raw .pcm or .wav files. Obviously, you need the game Dyad (or at least its SoundBin files) for this to work.

The UI project prompts for settings, and the ExtractionLibrary project does the heavy lifting.

The extractor can unpackage the files to two formats: raw .pcm files (open one at a time using "<a href="http://audacityteam.org/">Audacity</a> -> File -> Import -> Raw Data...") or .wav files (open using your favorite media player).

I assumed a lot of the .wav header information, but it seems correct when compared to the raw .pcm playback and is easy to change if incorrect.
