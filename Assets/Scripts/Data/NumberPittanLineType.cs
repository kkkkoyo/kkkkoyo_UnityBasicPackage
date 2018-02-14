using UnityEngine;
namespace Game.NumberPittan
{
    public class NumberPittanLineType : MonoBehaviour
    {
        public LineType lineType = LineType.Hidden;
    }
    /// <summary>
    /// Hidden:隠れ線
    /// Made:描画済み線
    /// Debug:デバック用問題生成時非表示になる線
    /// Answer:回答線（表示されていないものも含む）
    /// Draw:描画途中線
    /// </summary>
    public enum LineType : int
    {
        Hidden,
        Made,
        Debug,
        Answer,
        Draw
    }
}