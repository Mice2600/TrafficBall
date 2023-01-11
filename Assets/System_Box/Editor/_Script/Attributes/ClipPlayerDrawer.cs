using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector;
using Sirenix.Utilities.Editor;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using SystemBox.Simpls;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SystemBox.Editor
{
    public class ClipPlayerDrawer : OdinAttributeDrawer<ClipPlayerAttribute>
    {


        public static bool ClipSetted;
        protected override void DrawPropertyLayout(GUIContent label)
        {
            

            var clip = this.Property.BaseValueEntry.WeakSmartValue as AudioClip;
            if (!clip) 
            {
                Color GUIColor = GUI.color;
                if(ColorUtility.TryParseHtmlString(TColor.gRed[1], out Color newCol)) 
                    GUI.color = newCol;
                this.Property.BaseValueEntry.WeakSmartValue = EditorGUI.ObjectField(EditorGUILayout.GetControlRect(GUILayout.ExpandWidth(true)), label, clip, typeof(AudioClip), false) as AudioClip;
                GUI.color = GUIColor;
                return;
            }
            
            if (!ClipSetted) 
            {
                Selection.selectionChanged += AudioPlayerSettings.StopAllPlayers; ClipSetted = true;
                AudioPlayerSettings.StopAllPlayers();
            }

            if(AudioPlayerSettings.GetPlayer(clip).IsPlaying) Sirenix.Utilities.Editor.GUIHelper.RequestRepaint();
            //this.CallNextDrawer(label);
            SirenixEditorGUI.BeginBox("");
            {
                
                if(!this.Attribute.Hidelabel) 
                    SirenixEditorGUI.Title(string.IsNullOrEmpty(this.Attribute.Costumelabel)? this.Property.NiceName : this.Attribute.Costumelabel, 
                        "", this.Attribute.TextAlignment, this.Attribute.HorizontalLine, this.Attribute.BoldLabel);
                Rect RectOhHorizontalGrope = EditorGUILayout.BeginHorizontal();
                {
                   // if()
                    SirenixEditorGUI.BeginBox(GUILayout.Width(20), GUILayout.ExpandWidth(false));
                    Rect RectOfButton = EditorGUILayout.GetControlRect(GUILayout.Width(20), GUILayout.Height(15));
                    if (SirenixEditorGUI.IconButton(RectOfButton, (!AudioPlayerSettings.GetPlayer(clip).IsPlaying) ? EditorIcons.Play : EditorIcons.Stop)) 
                    {
                        
                        if (AudioPlayerSettings.GetPlayer(clip).IsPlaying) 
                        {
                            AudioPlayerSettings.StopAllPlayers();
                        }
                        else
                        {
                            AudioPlayerSettings.StopAllPlayers();
                            AudioPlayerSettings.GetPlayer(clip).Play();
                        }
                    }
                        
                    SirenixEditorGUI.EndBox();

                    Rect RectOfAudioFild = EditorGUILayout.GetControlRect(GUILayout.ExpandWidth(false));
                    RectOfAudioFild.x = RectOfButton.x + 25;
                    RectOfAudioFild.width = RectOhHorizontalGrope.width - 27;
                    this.Property.BaseValueEntry.WeakSmartValue = EditorGUI.ObjectField(RectOfAudioFild, clip, typeof(AudioClip), false) as AudioClip;
                }
                EditorGUILayout.EndHorizontal();
                if (clip == null) { SirenixEditorGUI.EndBox(); return; }

                Color GUIColor = GUI.color; GUI.color = new Color(0, 0, 0, 0);
                float NewOnTime = GUILayout.HorizontalSlider(AudioPlayerSettings.GetPlayer(clip).Progress, 0f, 1f, GUILayout.ExpandWidth(true), GUILayout.Height(50));
                if (AudioPlayerSettings.GetPlayer(clip).Progress != NewOnTime) 
                {
                    AudioPlayerSettings.StopAllPlayers();
                    AudioPlayerSettings.GetPlayer(clip).Play(); 
                    AudioPlayerSettings.GetPlayer(clip).SettTime(NewOnTime);
                }
                GUI.color = GUIColor;

                Rect RectOfAudioVisualer = EditorGUILayout.GetControlRect(GUILayout.ExpandWidth(true), GUILayout.Height(0));
                RectOfAudioVisualer.height = 25;
                RectOfAudioVisualer.y -= 50;
                RenderAmplitudeAwarePreview(this.Property.Path, RectOfAudioVisualer, clip, new Color(255 / 255f, 168 / 255f, 7 / 255f),
                    Color.Lerp(new Color(255 / 255f, 168 / 255f, 7 / 255f), Color.red, .3f), 3);
            }
            SirenixEditorGUI.EndBox();

            AudioPlayerSettings.GetPlayer(clip).Cheak();
            /*
            if (clip == null) return;
            var path = AssetDatabase.GetAssetPath(clip); if (path == null) return;
            var importer = AssetImporter.GetAtPath(path); if (importer == null) return;
            var assembly = Assembly.GetAssembly(typeof(AssetImporter)); if (assembly == null) return;
            var type = assembly.GetType("UnityEditor.AudioUtil"); if (type == null) return;
            var AudioUtil_GetMinMaxData = type.GetMethod("GetMinMaxData"); if (AudioUtil_GetMinMaxData == null) return;
            var minMaxData = AudioUtil_GetMinMaxData.Invoke(null, new object[] { importer }) as float[]; if (minMaxData == null) return;

            var r = EditorGUILayout.GetControlRect(GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            var curveColor = new Color(255 / 255f, 168 / 255f, 7 / 255f);
            int numChannels = clip.channels;
            int numSamples = minMaxData.Length / (2 * numChannels);
            float h = (float)r.height / numChannels;
            for (int channel = 0; channel < numChannels; channel++)
            {
                var channelRect = new Rect(r.x, r.y + channel * h, r.width, h);
                AudioCurveRendering.DrawMinMaxFilledCurve(
                    channelRect,
                    delegate (float x, out Color col, out float minValue, out float maxValue)
                    {
                        col = curveColor;
                        float p = Mathf.Clamp(x * (numSamples - 2), 0.0f, numSamples - 2);
                        int i = (int)Mathf.Floor(p);
                        int offset1 = (i * numChannels + channel) * 2;
                        int offset2 = offset1 + numChannels * 2;
                        minValue = Mathf.Min(minMaxData[offset1 + 1], minMaxData[offset2 + 1]);
                        maxValue = Mathf.Max(minMaxData[offset1 + 0], minMaxData[offset2 + 0]);
                        if (minValue > maxValue) { float tmp = minValue; minValue = maxValue; maxValue = tmp; }
                    }
                );
            }
            */
        }




        public delegate Color AudioCurveColorSetter(int channel, float t, float min, float max, float minOfAll, float maxOfAll);

        /// <summary>
        /// Render waveform preview of the clip in given rect. If clip is null, do nothing.
        /// </summary>
        /// <param name="rect">Rect in which the wave will be rendered</param>
        /// <param name="clip">AudioClip source</param>
        /// <param name="colorSetter">Delegate for coloring the wave. Default: Color(1,0.54902,0)</param>
        /// <param name="amplitudeScale">Y-scale amplification of the wave</param>
        private static void RenderPreview(Rect rect, AudioClip clip, AudioCurveColorSetter colorSetter = null, float amplitudeScale = 1)
        {
            if (!clip) return;

            amplitudeScale *= 0.95f;





            var path = AssetDatabase.GetAssetPath(clip); if (path == null) return;
            var importer = AssetImporter.GetAtPath(path); if (importer == null) return;
            var assembly = Assembly.GetAssembly(typeof(AssetImporter)); if (assembly == null) return;
            var type = assembly.GetType("UnityEditor.AudioUtil"); if (type == null) return;
            var AudioUtil_GetMinMaxData = type.GetMethod("GetMinMaxData"); if (AudioUtil_GetMinMaxData == null) return;
            var minMaxData_ = AudioUtil_GetMinMaxData.Invoke(null, new object[] { importer }) as float[]; if (minMaxData_ == null) return;




            float[] minMaxData = minMaxData_;

            float minOfAll = 0;
            float maxOfAll = 0;
            for (int i = 0; i < minMaxData.Length; i++)
            {
                minOfAll = Mathf.Min(minMaxData[i], minOfAll);
                maxOfAll = Mathf.Max(minMaxData[i], maxOfAll);
            }
            minOfAll *= amplitudeScale;
            maxOfAll *= amplitudeScale;

            int numChannels = clip.channels;
            int numSamples = (minMaxData == null) ? 0 : (minMaxData.Length / (2 * numChannels));

            float h = rect.height * 2;

            //for (int channel = 0; channel < numChannels; channel++)
            //{
            Rect channelRect = new Rect(rect.x, rect.y + h * 0 /*channel*/, rect.width, h);

            AudioCurveRendering.AudioMinMaxCurveAndColorEvaluator dlg = delegate (float x, out Color col, out float minValue, out float maxValue)
            {
                if (numSamples <= 0)
                {
                    minValue = 0.0f;
                    maxValue = 0.0f;
                }
                else
                {
                    float p = Mathf.Clamp(x * (numSamples - 2), 0.0f, numSamples - 2);
                    int i = (int)Mathf.Floor(p);
                    int offset1 = (i * numChannels + 0/*channel*/) * 2;
                    int offset2 = offset1 + numChannels * 2;
                    minValue = Mathf.Min(minMaxData[offset1 + 1], minMaxData[offset2 + 1]) * amplitudeScale;
                    maxValue = Mathf.Max(minMaxData[offset1 + 0], minMaxData[offset2 + 0]) * amplitudeScale;
                    if (minValue > maxValue) { float tmp = minValue; minValue = maxValue; maxValue = tmp; }
                }
                col = colorSetter?.Invoke(0/*channel*/, x, minValue, maxValue, minOfAll, maxOfAll) ?? new Color(1, 0.54902f, 0, 1);
            };

            AudioCurveRendering.DrawMinMaxFilledCurve(channelRect, dlg);
            // }
        }

        public static void RenderPreview(Rect rect, AudioClip clip, Color color, float amplitudeScale = 1)
        {
            RenderPreview(rect, clip, (_, __, ___, ____, _____, ______) => color, amplitudeScale);
        }

        public static void RenderTimeAwarePreview(Rect rect, AudioClip clip, Color start, Color finish, float amplitudeScale = 1)
        {
            RenderPreview(rect, clip, (_, t, ___, ____, _____, ______) => Color.Lerp(start, finish, t), amplitudeScale);
        }

        public static void RenderAmplitudeAwarePreview(string ID, Rect rect, AudioClip clip, Color lowAmp, Color highAmp, float amplitudeScale = 1)
        {
            RenderPreview(rect, clip, (channel, _Time, min, max, minOfAll, maxOfAll) =>
            {
                Color dd = Color.Lerp(lowAmp, highAmp, Mathf.Clamp01((max - min) / (maxOfAll - minOfAll)));
                dd = Color.Lerp(dd, Color.black,  (_Time > AudioPlayerSettings.GetPlayer(clip).Progress && AudioPlayerSettings.GetPlayer(clip).IsPlaying) ? .3f : 0);
                return dd;
            }
                , amplitudeScale);
        }








        public static void PlayClip(AudioClip clip, int startSample = 0, bool loop = false)
        {
            Assembly unityEditorAssembly = typeof(AudioImporter).Assembly;

            Type audioUtilClass = unityEditorAssembly.GetType("UnityEditor.AudioUtil");
            MethodInfo method = audioUtilClass.GetMethod(
                "PlayPreviewClip",
                BindingFlags.Static | BindingFlags.Public,
                null,
                new Type[] { typeof(AudioClip), typeof(int), typeof(bool) },
                null
            );
            method.Invoke(
                null,
                new object[] { clip, startSample, loop }
            );
        }

        public static void StopAllClips()
        {
            Assembly unityEditorAssembly = typeof(AudioImporter).Assembly;

            Type audioUtilClass = unityEditorAssembly.GetType("UnityEditor.AudioUtil");
            MethodInfo method = audioUtilClass.GetMethod(
                "StopAllPreviewClips",
                BindingFlags.Static | BindingFlags.Public,
                null,
                new Type[] { },
                null
            );
            method.Invoke(
                null,
                new object[] { }
            );
        }

        public static float GetClipPosition(AudioClip clip)
        {
            Assembly unityEditorAssembly = typeof(AudioImporter).Assembly;
            Type audioUtilClass = unityEditorAssembly.GetType("UnityEditor.AudioUtil");
            MethodInfo method = audioUtilClass.GetMethod(
                "GetPreviewClipPosition",
                BindingFlags.Static | BindingFlags.Public, 
                null,
                new Type[] { },
                null
                );

            float position = (float)method.Invoke(
                null,
                new object[] {
                
            }
            );

            return position;
        }


        public static void SetClipSamplePosition(AudioClip clip, int iSamplePosition)
        {
            Assembly unityEditorAssembly = typeof(AudioImporter).Assembly;
            Type audioUtilClass = unityEditorAssembly.GetType("UnityEditor.AudioUtil");
            MethodInfo method = audioUtilClass.GetMethod(
                "SetPreviewClipSamplePosition",
                BindingFlags.Static | BindingFlags.Public
                );

            method.Invoke(
                null,
                new object[] {
                clip,
                iSamplePosition
            }
            );
        }



























    }

    public static class AudioPlayerSettings
    {

        private static readonly Dictionary<AudioClip, Player> PlayerAudioClipDatabase = new Dictionary<AudioClip, Player>();



        public static Player GetPlayer(AudioClip audioClip)
        {
            if (audioClip == null) return null;
            if (PlayerAudioClipDatabase.ContainsKey(audioClip))
                return PlayerAudioClipDatabase[audioClip];
            var pp = new Player(audioClip);
            PlayerAudioClipDatabase.Add(audioClip, pp);
            return pp;
        }

        public static void StopAllPlayers()
        {
            foreach (Player player in PlayerAudioClipDatabase.Values)
                if (player != null)
                    player.Stop();
            PlayerAudioClipDatabase.Clear();
        }
        public class Player 
        {
        public Player(AudioClip audioClip) { AudioClip = audioClip; }
        public AudioClip AudioClip;

            private AudioSource m_audioSource;

            public AudioSource AudioSource
            {
                get
                {
                    if (m_audioSource != null) return m_audioSource;
                    m_audioSource = EditorUtility.CreateGameObjectWithHideFlags("Soundy Player", HideFlags.DontSave, typeof(AudioSource)).GetComponent<AudioSource>();
                    return m_audioSource;
                }
            }

            public bool IsPlaying { get { return m_audioSource != null && m_audioSource.isPlaying; } }
            


            public float Progress { get { return m_audioSource != null && (IsPlaying) ? (float)Math.Round(m_audioSource.time / m_audioSource.clip.length, 3) : 0; } }


            public float PlaybackTimeMinutes { get { return m_audioSource != null && (IsPlaying) ? GetMinutes(m_audioSource.time) : 0; } }
            public float PlaybackTimeSeconds { get { return m_audioSource != null && (IsPlaying) ? GetSeconds(m_audioSource.time) : 0; } }
            public float ClipLengthMinutes { get { return m_audioSource != null && m_audioSource.clip != null && (IsPlaying) ? GetMinutes(m_audioSource.clip.length) : 0; } }
            public float ClipLengthSeconds { get { return m_audioSource != null && m_audioSource.clip != null && (IsPlaying) ? GetSeconds(m_audioSource.clip.length) : 0; } }

            public string PlaybackTimeLabel { get { return GetTimePretty(PlaybackTimeMinutes, PlaybackTimeSeconds); } }
            public string ClipLengthLabel { get { return GetTimePretty(ClipLengthMinutes, ClipLengthSeconds); } }
            public string ClipName { get { return m_audioSource.clip.name; } }
            public string DurationLabel { get { return "(" + PlaybackTimeLabel + " / " + ClipLengthLabel + ")"; } }
            public string ProgressLabel { get { return ClipName + " - " + DurationLabel; } }

            private static float GetMinutes(float seconds) { return Mathf.Floor(seconds / 60); }
            private static float GetSeconds(float seconds) { return Mathf.RoundToInt(seconds % 60); }
            private static string GetTimePretty(float seconds) { return GetTimePretty(GetMinutes(seconds), GetSeconds(seconds)); }
            private static string GetTimePretty(float minutes, float seconds) { return (minutes < 10 ? "0" : "") + minutes + ":" + (seconds < 10 ? "0" : "") + seconds; }


            private bool CanPlay => AudioClip != null;

            public void Play()
            {
                if (!CanPlay) return;
                if (IsPlaying) Stop();
                EditorUtility.audioMasterMute = false;
                AudioSource.clip = AudioClip;
                AudioSource.Play();
            }

            public void Stop()
            {
                if (m_audioSource == null) return;
                m_audioSource.Stop();
                UnityEngine.Object.DestroyImmediate(m_audioSource.gameObject);
                m_audioSource = null;
            }

            public void Cheak()
            {
                if (m_audioSource != null && !IsPlaying)
                {
                    UnityEngine.Object.DestroyImmediate(m_audioSource.gameObject);
                    m_audioSource = null;
                    return;
                }
                
                if (Event.current.type == EventType.MouseDown && (IsPlaying)) 
                {
                    Stop();
                }
            }

            public void SettTime(float NTime) 
            {
                AudioSource.time = AudioSource.clip.length * NTime;
            }

        }

    }

}

























