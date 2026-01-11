using UnityEngine;
using UnityEngine.UI;
using S1API.TVApp;
using S1API.UI;

namespace HelloWorldTVApp
{
    /// <summary>
    /// A minimal Hello World TV app demonstrating the S1API TV app system.
    /// </summary>
    public class HelloWorldTVApp : TVApp
    {
        #region Abstract Properties

        /// <inheritdoc />
        protected override string AppName => "HelloWorld";

        /// <inheritdoc />
        protected override string AppTitle => "Hello World";

        /// <inheritdoc />
        protected override Sprite Icon => _cachedIcon ??= CreateIcon();

        #endregion

        #region State

        private Text? _messageText;
        private float _timer;
        private int _colorIndex;
        private static Sprite? _cachedIcon;

        private static readonly Color[] Colors = {
            Color.white,
            Color.cyan,
            Color.yellow,
            Color.green,
            Color.magenta
        };

        #endregion

        #region Lifecycle

        /// <inheritdoc />
        protected override void OnCreatedUI(GameObject container)
        {
            // Create background with explicit sizeDelta (required for WorldSpace canvas)
            var background = new GameObject("Background");
            background.transform.SetParent(container.transform, false);

            var bgRT = background.AddComponent<RectTransform>();
            bgRT.anchorMin = new Vector2(0.5f, 0.5f);
            bgRT.anchorMax = new Vector2(0.5f, 0.5f);
            bgRT.pivot = new Vector2(0.5f, 0.5f);
            bgRT.sizeDelta = new Vector2(500, 350);
            bgRT.anchoredPosition = Vector2.zero;

            var bgImg = background.AddComponent<RawImage>();
            bgImg.texture = CreateSolidTexture(new Color(0.05f, 0.05f, 0.15f, 1f));
            bgImg.raycastTarget = false;

            // Create "Hello World" text centered on screen
            _messageText = UIFactory.Text(
                "HelloText",
                "Hello World!",
                container.transform,
                48,
                TextAnchor.MiddleCenter,
                FontStyle.Bold
            );

            var textRT = _messageText.GetComponent<RectTransform>();
            textRT.anchorMin = new Vector2(0.5f, 0.5f);
            textRT.anchorMax = new Vector2(0.5f, 0.5f);
            textRT.pivot = new Vector2(0.5f, 0.5f);
            textRT.sizeDelta = new Vector2(400, 100);
            textRT.anchoredPosition = Vector2.zero;

            // Create subtitle text
            var subtitle = UIFactory.Text(
                "Subtitle",
                "S1API TV App Demo",
                container.transform,
                18,
                TextAnchor.MiddleCenter,
                FontStyle.Normal
            );
            subtitle.color = new Color(1f, 1f, 1f, 0.6f);

            var subRT = subtitle.GetComponent<RectTransform>();
            subRT.anchorMin = new Vector2(0.5f, 0.5f);
            subRT.anchorMax = new Vector2(0.5f, 0.5f);
            subRT.pivot = new Vector2(0.5f, 0.5f);
            subRT.sizeDelta = new Vector2(300, 40);
            subRT.anchoredPosition = new Vector2(0, -50);
        }

        /// <inheritdoc />
        protected override void OnOpened()
        {
            _timer = 0f;
            _colorIndex = 0;
            if (_messageText != null)
            {
                _messageText.color = Colors[0];
            }
        }

        /// <inheritdoc />
        protected override void OnUpdate()
        {
            // Cycle through colors every second
            _timer += Time.deltaTime;
            if (_timer >= 1f)
            {
                _timer = 0f;
                _colorIndex = (_colorIndex + 1) % Colors.Length;
                if (_messageText != null)
                {
                    _messageText.color = Colors[_colorIndex];
                }
            }
        }

        #endregion

        #region Icon

        private static Sprite CreateIcon()
        {
            int size = 256;
            var tex = new Texture2D(size, size);
            Color bgColor = new Color(0.1f, 0.1f, 0.2f);
            Color fgColor = Color.cyan;

            // Fill background
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    tex.SetPixel(x, y, bgColor);
                }
            }

            // Draw "H" shape
            int margin = 40;
            int barWidth = 30;

            // Left vertical bar of H
            for (int x = margin; x < margin + barWidth; x++)
            {
                for (int y = margin; y < size - margin; y++)
                {
                    tex.SetPixel(x, y, fgColor);
                }
            }

            // Right vertical bar of H
            for (int x = size - margin - barWidth; x < size - margin; x++)
            {
                for (int y = margin; y < size - margin; y++)
                {
                    tex.SetPixel(x, y, fgColor);
                }
            }

            // Horizontal bar of H
            int midY = size / 2;
            for (int x = margin; x < size - margin; x++)
            {
                for (int y = midY - barWidth / 2; y < midY + barWidth / 2; y++)
                {
                    tex.SetPixel(x, y, fgColor);
                }
            }

            tex.Apply();
            return Sprite.Create(tex, new Rect(0, 0, size, size), new Vector2(0.5f, 0.5f));
        }

        private static Texture2D CreateSolidTexture(Color color)
        {
            var tex = new Texture2D(4, 4);
            for (int x = 0; x < 4; x++)
                for (int y = 0; y < 4; y++)
                    tex.SetPixel(x, y, color);
            tex.Apply();
            return tex;
        }

        #endregion
    }
}
