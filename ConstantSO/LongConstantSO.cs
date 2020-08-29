

[System.Serializable]
public class LongConstantSO : ConstantSO<long> { }

[System.Serializable]
public class LongConstantReference : ConstantReference<LongConstantSO, long>
{
	public LongConstantReference( long startValue = 0 ) : base( startValue ) { }
	public static implicit operator long( LongConstantReference c ) => c.Value;
}