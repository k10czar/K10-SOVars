

[System.Serializable]
public class StringConstantSO : ConstantSO<string> { }

[System.Serializable]
public class StringConstantReference : ConstantReference<StringConstantSO, string>
{
	public StringConstantReference( string startValue = "" ) : base( startValue ) { }
	public static implicit operator string( StringConstantReference c ) => c.Value;
}