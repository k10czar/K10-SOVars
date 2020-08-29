

[System.Serializable]
public class UIntConstantSO : ConstantSO<uint> { }

[System.Serializable]
public class UIntConstantReference : ConstantReference<UIntConstantSO, uint>
{
	public UIntConstantReference( uint startValue = 0 ) : base( startValue ) { }
	public static implicit operator uint( UIntConstantReference c ) => c.Value;
}