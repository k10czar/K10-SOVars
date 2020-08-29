

[System.Serializable]
public class FloatConstantSO : ConstantSO<float> { }

[System.Serializable]
public class FloatConstantReference : ConstantReference<FloatConstantSO, float>
{
	public FloatConstantReference( float startValue = 0 ) : base( startValue ) { }
	public static implicit operator float( FloatConstantReference c ) => c.Value;
}