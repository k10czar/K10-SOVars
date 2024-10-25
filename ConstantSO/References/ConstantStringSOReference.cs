using UnityEngine;

public class ConstantStringSOReference : IValueProvider<string>
{
	[SerializeField,InlineProperties] StringConstantSO _reference;

	public string Value => ( _reference != default ) ? _reference.Value : default;
}
