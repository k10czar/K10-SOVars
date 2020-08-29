


[System.Serializable]
public class DoubleConstantSO : ConstantSO<double> { }


[System.Serializable]
public class DoubleConstantReference : ConstantReference<DoubleConstantSO, double>
{
	public DoubleConstantReference( double startValue = 0 ) : base( startValue ) { }
	public static implicit operator double( DoubleConstantReference c ) => c.Value;
}