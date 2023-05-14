namespace Objects
{
  public enum LineTypeEnum
  {
    /// <summary>
    /// <code>
    /// Infinite &lt;= t &lt;= Infinite
    /// </code>
    /// </summary>
    Line,

    /// <summary>
    /// <code>
    /// 0 &lt;= t &lt;= 1
    /// </code>
    /// </summary>
    Segment,

    /// <summary>
    /// <code>
    /// 0 &lt;= t &lt;= Infinite
    /// </code>
    /// </summary>
    Ray
  }
}