

[System.Serializable]
public class IntConstantSO : ConstantSO<int> { }

[System.Serializable]
public class IntConstantReference : ConstantReference<IntConstantSO, int>
{
	public IntConstantReference( int startValue = 0 ) : base( startValue ) { }
	public static implicit operator int( IntConstantReference c ) => c.Value;
}