

[System.Serializable]
public class ByteConstantSO : ConstantSO<byte> { }

[System.Serializable]
public class ByteConstantReference : ConstantReference<ByteConstantSO, byte>
{
	public ByteConstantReference( byte startValue = 0 ) : base( startValue ) { }
	public static implicit operator byte( ByteConstantReference c ) => c.Value;
}