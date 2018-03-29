using System;

/// <summary>
/// 对Attribute Value Array的扩展
/// </summary>
public static class AttributeArrayExtentions  {
    /// <summary>
    /// 根据属性名称缩略词获取属性值对象
    /// </summary>
    /// <param name="values"></param>
    /// <param name="abbr"></param>
    /// <returns></returns>
    public static AttributeValue GetAttributeValue(this AttributeValue[] values, string abbr)
    {
        foreach(AttributeValue item in values)
        {
            if(item.attribute.abbr == abbr)
            {
                return item;
            }
        }
        return null;
    }
    /// <summary>
    /// 增加属性值（备注：如果值是负数，则实际效果是减少属性值）
    /// </summary>
    /// <param name="values"></param>
    /// <param name="abbr"></param>
    /// <param name="value"></param>
    //[Obsolete("请改用带 max 参数的版本")]
    public static void IncreaseAttributeValue(this AttributeValue[] values, string abbr, float value)
    {
        foreach (AttributeValue item in values)
        {
            if (item.attribute.abbr == abbr)
            {
                item.value += value;
                if (item.value < 0)
                {
                    item.value = 0;
                }
            }
        }
    }

    /// <summary>
    /// 增加属性值（备注：如果值是负数，则实际效果是减少属性值）
    /// </summary>
    /// <param name="values"></param>
    /// <param name="abbr"></param>
    /// <param name="value"></param>
    public static void IncreaseAttributeValue(this AttributeValue[] values, string abbr, float value, float max)
    {
        foreach (AttributeValue item in values)
        {
            if (item.attribute.abbr == abbr)
            {
                item.value += value;
                if (item.value > max)
                {
                    item.value = max;
                }
                else if (item.value < 0)
                {
                    item.value = 0;
                }
            }
        }
    }

}
