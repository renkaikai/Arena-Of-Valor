using System;

[Serializable]
public class AttributeValue {
    public AttributeItem attribute;
    public float value;

    public AttributeValue Clone()
    {
        AttributeValue copy = new AttributeValue();
        copy.attribute = attribute;
        copy.value = value;
        return copy;
    }
}
