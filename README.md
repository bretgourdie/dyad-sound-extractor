# dyad-sound-extractor
Extracts the packaged .bsd files from Dyad's SoundBin folder and writes them as raw .pcm or .wav files.

UI project prompts for settings, ExtractionLibrary does the heavy lifting.

Obviously, you need Dyad's SoundBin files for this to work.

The extractor can unpackage the files to two formats: raw .pcm files (open one at a time using "Audacity -> File -> Import -> Raw Data...") or .wav files (open using your favorite media player).

I guessed at a lot of the .wav header information, but it seems correct when compared to the raw .pcm playback.
