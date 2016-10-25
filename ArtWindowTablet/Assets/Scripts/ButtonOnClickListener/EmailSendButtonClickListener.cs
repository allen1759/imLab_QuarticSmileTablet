using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EmailSendButtonClickListener {

	Director director;

	public EmailSendButtonClickListener (Director director)
	{
		this.director = director;
	}

	public void OnClick (string email)
	{
		director.SendStateCommand ("EMAIL_YES_" + email);
	}
}
