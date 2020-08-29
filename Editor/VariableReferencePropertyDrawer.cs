using UnityEditor;
using K10.EditorGUIExtention;
using UnityEngine;

public class VariableReferencePropertyDrawer<refT, T> : PropertyDrawer where refT : VariableSO<T> where T : struct
{
	protected virtual float VALUE_FIELD_WIDTH => 80;
	protected const float LOCK_BUTTON_WIDTH = 16;
	bool _locked = true;

	public override void OnGUI( Rect area, SerializedProperty prop, GUIContent label )
	{
		var reference = prop.FindPropertyRelative( "_reference" );
		var property = prop.FindPropertyRelative( "_value" );
		var val = property.FindPropertyRelative( "_value" );
		var oldValue = val.Get<T>();
		var refVar = reference.objectReferenceValue as refT;
		var validRef = refVar != null;
		if( validRef ) oldValue = refVar.Value;
		EditorGUI.BeginDisabledGroup( validRef && _locked );
		var firstRectW = EditorGUIUtility.labelWidth + VALUE_FIELD_WIDTH;

		var fieldArea = area.RequestLeft( firstRectW + 24 - ( validRef ? LOCK_BUTTON_WIDTH : 0 ) );
		property.DebugWatcherField<T>( fieldArea.RequestRight( 20 ) );
		var newValue = fieldArea.CutRight( 24 ).FieldOf<T>( label, oldValue );

		EditorGUI.EndDisabledGroup();
		if( validRef && IconButton.Draw( area.RequestLeft( firstRectW + 24 ).RequestRight( LOCK_BUTTON_WIDTH ), _locked ? "lockOn" : "lockOff", _locked ? 'X' : 'O' ) ) _locked = !_locked;
		if( !newValue.Equals( oldValue ) )
		{
			property.TriggerMethod( BoolState.SET_METHOD_NAME, newValue );
			if( validRef ) refVar.Setter( newValue );
			val.Set( newValue );
		}
		if( validRef ) refVar.EditorChangeValue( newValue );

		EditorGuiIndentManager.New( 0 );
		var newSO = ScriptableObjectField.Draw<refT>( area.CutLeft( firstRectW ), reference, "[_Configurations_]/Values/Variables/" );
		EditorGuiIndentManager.Revert();

		if( newSO && !validRef && ( reference.objectReferenceValue is refT newRef ) ) newRef.EditorChangeValue( newValue );
	}
}