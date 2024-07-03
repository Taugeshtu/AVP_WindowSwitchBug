using Unity.PolySpatial;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BugDemo : MonoBehaviour {
	[Header( "Polyspatial setup" )]
	[SerializeField] private VolumeCameraWindowConfiguration _unboundConfig;
	[SerializeField] private VolumeCameraWindowConfiguration _boundConfig;
	[SerializeField] private VolumeCamera _volumeCamera;
	
	[Header( "UI setup" )]
	[SerializeField] private Button _editButton;
	[SerializeField] private Button _doneButton;
	
	[SerializeField] private TMP_InputField _input;
	[SerializeField] private TMP_Text _display;
	
	[Header( "State switching links" )]
	[SerializeField] private GameObject _editorRoot;
	[SerializeField] private GameObject _sceneRoot;
	
	void Awake() {
		_input.text = _display.text;
		
		_editButton.onClick.AddListener( () => _Sync( true ) );
		_doneButton.onClick.AddListener( () => _Sync( false ) );
		_input.onSubmit.AddListener( (newText) => { _display.text = newText; } );
		
		_Sync( false );
	}
	
	private void _Sync( bool isEditing ) {
		_sceneRoot.SetActive( !isEditing );
		_editorRoot.SetActive( isEditing );
	}
}
