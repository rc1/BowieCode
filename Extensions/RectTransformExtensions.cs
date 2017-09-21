using UnityEngine;


namespace BowieCode {

    /// <summary>
    /// Collection of RectTransformExtensions collated from:
    /// - https://stackoverflow.com/a/26436178
    /// - https://forum.unity.com/threads/test-if-ui-element-is-visible-on-screen.276549/#post-2978773
    /// </summary>
    public static class RectTransformExtensions {

        public static void SetDefaultScale ( this RectTransform trans ) {
            trans.localScale = new Vector3( 1, 1, 1 );
        }

        public static void SetPivotAndAnchors ( this RectTransform trans, Vector2 aVec ) {
            trans.pivot = aVec;
            trans.anchorMin = aVec;
            trans.anchorMax = aVec;
        }

        public static Vector2 GetSize ( this RectTransform trans ) {
            return trans.rect.size;
        }

        public static float GetWidth ( this RectTransform trans ) {
            return trans.rect.width;
        }

        public static float GetHeight ( this RectTransform trans ) {
            return trans.rect.height;
        }

        public static void SetPositionOfPivot ( this RectTransform trans, Vector2 newPos ) {
            trans.localPosition = new Vector3( newPos.x, newPos.y, trans.localPosition.z );
        }

        public static void SetLeftBottomPosition ( this RectTransform trans, Vector2 newPos ) {
            trans.localPosition = new Vector3( newPos.x + ( trans.pivot.x * trans.rect.width ),
                                               newPos.y + ( trans.pivot.y * trans.rect.height ),
                                               trans.localPosition.z );
        }

        public static void SetLeftTopPosition ( this RectTransform trans, Vector2 newPos ) {
            trans.localPosition = new Vector3( newPos.x + ( trans.pivot.x * trans.rect.width ),
                                               newPos.y - ( ( 1f - trans.pivot.y ) * trans.rect.height ),
                                               trans.localPosition.z );
        }

        public static void SetRightBottomPosition ( this RectTransform trans, Vector2 newPos ) {
            trans.localPosition = new Vector3( newPos.x - ( ( 1f - trans.pivot.x ) * trans.rect.width ),
                                               newPos.y + ( trans.pivot.y * trans.rect.height ),
                                               trans.localPosition.z );
        }

        public static void SetRightTopPosition ( this RectTransform trans, Vector2 newPos ) {
            trans.localPosition = new Vector3( newPos.x - ( ( 1f - trans.pivot.x ) * trans.rect.width ),
                                               newPos.y - ( ( 1f - trans.pivot.y ) * trans.rect.height ),
                                               trans.localPosition.z );
        }

        public static void SetSize ( this RectTransform trans, Vector2 newSize ) {
            Vector2 oldSize = trans.rect.size;
            Vector2 deltaSize = newSize - oldSize;
            trans.offsetMin = trans.offsetMin - new Vector2( deltaSize.x * trans.pivot.x, deltaSize.y * trans.pivot.y );
            trans.offsetMax = trans.offsetMax +
                              new Vector2( deltaSize.x * ( 1f - trans.pivot.x ), deltaSize.y * ( 1f - trans.pivot.y ) );
        }

        public static void SetWidth ( this RectTransform trans, float newSize ) {
            SetSize( trans, new Vector2( newSize, trans.rect.size.y ) );
        }

        public static void SetHeight ( this RectTransform trans, float newSize ) {
            SetSize( trans, new Vector2( trans.rect.size.x, newSize ) );
        }

        /// <summary>
        /// Counts the bounding box corners of the given RectTransform that are visible from the given Camera in screen space.
        /// </summary>
        /// <returns>The amount of bounding box corners that are visible from the Camera.</returns>
        /// <param name="rectTransform">Rect transform.</param>
        /// <param name="camera">Camera.</param>
        private static int CountCornersVisibleFrom ( this RectTransform rectTransform, Camera camera ) {
            Rect screenBounds =
                new Rect( 0f, 0f, Screen.width,
                          Screen.height ); // Screen space bounds (assumes camera renders across the entire screen)
            Vector3[] objectCorners = new Vector3[4];
            rectTransform.GetWorldCorners( objectCorners );

            int visibleCorners = 0;
            Vector3 tempScreenSpaceCorner; // Cached
            for ( var i = 0; i < objectCorners.Length; i++ ) // For each corner in rectTransform
            {
                tempScreenSpaceCorner =
                    camera.WorldToScreenPoint( objectCorners
                                                   [ i ] ); // Transform world space position of corner to screen space
                if ( screenBounds.Contains( tempScreenSpaceCorner ) ) // If the corner is inside the screen
                {
                    visibleCorners++;
                }
            }

            return visibleCorners;
        }

        /// <summary>
        /// Determines if this RectTransform is fully visible from the specified camera.
        /// Works by checking if each bounding box corner of this RectTransform is inside the cameras screen space view frustrum.
        /// </summary>
        /// <returns><c>true</c> if is fully visible from the specified camera; otherwise, <c>false</c>.</returns>
        /// <param name="rectTransform">Rect transform.</param>
        /// <param name="camera">Camera.</param>
        public static bool IsFullyVisibleFrom ( this RectTransform rectTransform, Camera camera ) {
            return CountCornersVisibleFrom( rectTransform, camera ) == 4; // True if all 4 corners are visible
        }

        /// <summary>
        /// Determines if this RectTransform is at least partially visible from the specified camera.
        /// Works by checking if any bounding box corner of this RectTransform is inside the cameras screen space view frustrum.
        /// </summary>
        /// <returns><c>true</c> if is at least partially visible from the specified camera; otherwise, <c>false</c>.</returns>
        /// <param name="rectTransform">Rect transform.</param>
        /// <param name="camera">Camera.</param>
        public static bool IsVisibleFrom ( this RectTransform rectTransform, Camera camera ) {
            return CountCornersVisibleFrom( rectTransform, camera ) > 0; // True if any corners are visible
        }
    }
}