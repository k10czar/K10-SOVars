using UnityEditor;
using K10.EditorGUIExtention;
using UnityEngine;

public class ConstantReferencePropertyDrawer<refT, T> : PropertyDrawer where refT : ConstantSO<T>
{
	protected virtual float VALUE_FIELD_WIDTH => 80;
	protected const float LOCK_BUTTON_WIDTH = 16;
	bool _locked = true;

	public override void OnGUI( Rect area, SerializedProperty prop, GUIContent label )
	{
		var reference = prop.FindPropertyRelative( "_reference" );
		var val = prop.FindPropertyRelative( "_value" );
		var oldValue = val.Get<T>();
		var refVar = reference.objectReferenceValue as refT;
		var validRef = refVar != null;
		if( validRef ) oldValue = refVar.Value;
		EditorGUI.BeginDisabledGroup( validRef && _locked );
		var firstRectW = EditorGUIUtility.labelWidth + VALUE_FIELD_WIDTH;

		var fieldArea = area.RequestLeft( firstRectW - ( validRef ? LOCK_BUTTON_WIDTH : 0 ) );
		var newValue = fieldArea.FieldOf<T>( label, oldValue );
		EditorGUI.EndDisabledGroup();
		if( validRef && IconButton.Draw( area.RequestLeft( firstRectW ).RequestRight( LOCK_BUTTON_WIDTH ), _locked ? "lockOn" : "lockOff", _locked ? 'X' : 'O' ) ) _locked = !_locked;
		val.Set<T>( newValue );
		if( validRef ) refVar.EditorChangeValue( newValue );

		EditorGuiIndentManager.New( 0 );
		var newSO = ScriptableObjectField.Draw<refT>( area.CutLeft( firstRectW ), reference, "[_Configurations_]/Values/Constants/" );
		EditorGuiIndentManager.Revert();

		if( newSO && !validRef && ( reference.objectReferenceValue is refT newRef ) ) newRef.EditorChangeValue( newValue );
	}
}