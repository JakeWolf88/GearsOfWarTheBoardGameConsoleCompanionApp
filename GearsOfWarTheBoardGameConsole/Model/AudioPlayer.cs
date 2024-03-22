using NAudio.Wave;

public class AudioPlayer
{
    public async Task PlayAudio(string audioFilePath, CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            using (var waveOut = new WaveOutEvent())
            using (var audioFileReader = new AudioFileReader(audioFilePath))
            {
                waveOut.Init(audioFileReader);

                // TaskCompletionSource to signal completion of playback
                var playbackCompleted = new TaskCompletionSource<bool>();

                // Hook up the PlaybackStopped event
                waveOut.PlaybackStopped += (sender, eventArgs) =>
                {
                    // When playback is stopped, set the TaskCompletionSource result
                    playbackCompleted.SetResult(true);
                };

                // Start playback
                waveOut.Play();

                // Wait for playback to complete or cancellation to be requested
                await Task.WhenAny(playbackCompleted.Task, Task.Delay(-1, cancellationToken));

                // If cancellation is requested, stop playback
                if (cancellationToken.IsCancellationRequested)
                {
                    waveOut.Stop();
                    return;
                }
            }
        }
    }
}
