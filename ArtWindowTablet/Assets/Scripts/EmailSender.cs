using UnityEngine;
using System;
using System.Collections;
using System.Threading;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

public class EmailSender
{
	private string myEmail, otherEmail;
	private SmtpClient smtpServer;
	private bool isSending;

	private System.Text.Encoding encode;

	private byte[] img1, img2;

	public EmailSender ()
	{
		myEmail = "";
		otherEmail = "";

		smtpServer = new SmtpClient ("smtp.gmail.com");
		smtpServer.Port = 587;
		smtpServer.Credentials = new System.Net.NetworkCredential ("quarticsmile@csie.ntu.edu.tw", "F4L7ZyS3KNGH62") as ICredentialsByHost;
		smtpServer.EnableSsl = true;
		ServicePointManager.ServerCertificateValidationCallback = 
			delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) {
			return true;
		};

		isSending = false;
		encode = System.Text.Encoding.UTF8;
	}

	public void init ()
	{
		myEmail = "";
		otherEmail = "";

		isSending = true;
	}

	public void loadImage (byte[] image1, byte[] image2)
	{
		img1 = new byte[image1.Length];
		img2 = new byte[image2.Length];
		image1.CopyTo (img1, 0);
		image2.CopyTo (img2, 0);

//		Rect rec = new Rect (0, 0, 512, 512);
//		Texture2D tex = new Texture2D (2, 2);
//		Texture2D dst = new Texture2D(480, 480);;
//		tex.LoadImage (img1);
//		Sprite spr = Sprite.Create (tex, rec, new Vector2 (.5f, .5f));
//		Color[] pixels = spr.texture.GetPixels (16, 16, 480, 480);
//		dst = new Texture2D(480, 480);
//		dst.SetPixels (pixels);
//		dst.Apply ();
//		img1 = dst.EncodeToPNG ();
//
//		tex = new Texture2D (2, 2);
//		tex.LoadImage (img2);
//		spr = Sprite.Create (tex, rec, new Vector2 (.5f, .5f));
//		pixels = spr.texture.GetPixels (16, 16, 480, 480);
//		dst = new Texture2D(480, 480);
//		dst.SetPixels (pixels);
//		dst.Apply ();
//		img2 = dst.EncodeToPNG ();
	}

	public void SetMyEmail(String str)
	{
		myEmail = str;

		if (otherEmail != "" && !isSending) {
			isSending = true;
			Thread emailThread = new Thread (SendEmail);
			emailThread.Start ();
		}
	}

	public void SetOtherEmail(String str)
	{
		otherEmail = str;

		if (myEmail != "" && !isSending) {
			isSending = true;
			Thread emailThread = new Thread (SendEmail);
			emailThread.Start ();
		}
	}

	public void SendEmail()
	{
		if (myEmail == "" || otherEmail == "") {
			init ();
			return;
		}

		if (!isValid (myEmail)) {
			Debug.Log (myEmail + " is not valid email address");
			init ();
			return;
		}
			
		
		MailMessage mail = new MailMessage ();

		mail.From = new MailAddress ("quarticsmile@csie.ntu.edu.tw");
		mail.To.Add (myEmail);

//		String[] emailAdd = new String[] { "12kjljew@123Z", "allen1759@gmail.com", "allen369123@gmail.com", "allen1759@yahoo.com.tw", "allen_1759@hotmail.com"  };
//		String[] emailAdd = new String[] { "hung@csie.ntu.edu.tw ", "fanger@csie.ntu.edu.tw", "yinglien@ntu.edu.tw", "fairylynz@gmail.com", "mailyxc@gmail.com", "wenching33@gmail.com", "dayuansmile@gmail.com", "shenchihtsung@gmail.com", "hyde1234r@yahoo.com.tw", "stanley538@gmail.com", "hsnuhrt@gmail.com", "yanin@livemail.tw", "robert19881004@hotmail.com", "yinpenghuang@gmail.com", "designmit88@gmail.com", "shakingwei@gmail.com", "zbabqzbabqr@gmail.com", "j810326@gmail.com", "andy80110500@hotmail.com.tw", "yujiehung@gmail.com", "r_2123b@hotmail.com", "b98201043@ntu.edu.tw", "sam0276211@gmail.com", "clarenceliang@foxmail.com", "siqiyaoyao@gmail.com", "lanmin09@gmail.com", "s8803111@gmail.com", "b00705025@ntu.edu.tw", "sally31643@gmail.com", "b00902015@ntu.edu.tw", "r04922115@ntu.edu.tw", "benben994@hotmail.com", "b129517129@hotmail.com", "r04944042@ntu.edu.tw", "r04944043@ntu.edu.tw", "r04944046@ntu.edu.tw", "allen1759@gmail.com", "sayuri07290901@gmail.com", "xinwen218@gmail.com", "wj4y78308@gmail.com", "liebe_821227@yahoo.com.tw", "u10116032@gmail.com", "bright5528@gmail.com", "kuoandy1@gmail.com", "b01902039@ntu.edu.tw", "b02902010@ntu.edu.tw", "b02902036@ntu.edu.tw", "b02902014@ntu.edu.tw", "b02902083@ntu.edu.tw", "b02902101@ntu.edu.tw" };
//		String[] emailAdd = new string[] {
//			"hung@csie.ntu.edu.tw",
//			"fanger@csie.ntu.edu.tw",
//			"yinglien@ntu.edu.tw",
//			"mailyxc@gmail.com",
//			"dayuansmile@gmail.com",
//			"shenchihtsung@gmail.com",
//			"hyde1234r@yahoo.com.tw",
//			"stanley538@gmail.com",
//			"hsnuhrt@gmail.com",
//			"yanin@livemail.tw",
//			"robert19881004@hotmail.com",
//			"yinpenghuang@gmail.com",
//			"d03944012@ntu.edu.tw",
//			"sywei@iii.org.tw",
//			"yeti0193275@gmail.com",
//			"zbabqr@gmail.com",
//			"zackwu525@gmail.com",
//			"vacuityhu@iis.sinica.edu.tw",
//			"leplep418@gmail.com",
//			"j810326@gmail.com",
//			"r_2123b@hotmail.com",
//			"sam0276211@gmail.com",
//			"lanmin09@gmail.com",
//			"s8803111@gmail.com",
//			"b00705025@ntu.edu.tw",
//			"sally31643@gmail.com",
//			"b00902015@ntu.edu.tw",
//			"r04922115@ntu.edu.tw",
//			"benben994@hotmail.com",
//			"b129517129@hotmail.com",
//			"r04944042@ntu.edu.tw",
//			"alan96169@gmail.com",
//			"r04944046@ntu.edu.tw",
//			"allen1759@gmail.com",
//			"huyanggzu@gmail.com",
//			"sayuri07290901@gmail.com",
//			"xinwen218@gmail.com",
//			"wj4y78308@gmail.com",
//			"liebe_821227@yahoo.com.tw",
//			"u10116032@gmail.com",
//			"r05944043@ntu.edu.tw",
//			"b02902010@ntu.edu.tw",
//			"b02902036@ntu.edu.tw",
//			"b02902014@ntu.edu.tw",
//			"b02902083@ntu.edu.tw",
//			"b02902101@ntu.edu.tw",
//			"b03902088@ntu.edu.tw",
//			"b03902102@ntu.edu.tw"
//		};
//
//		foreach (String str in emailAdd) {
//			mail.To.Add (str);
//		}
//		foreach (String str in emailAdd) {
//			if (!str) {
//				Debug.Log (str);
//			}
//		}

		// 支援 HTML 語法
		mail.IsBodyHtml = true;
		// E-Mail 編碼
		mail.SubjectEncoding = encode;
		mail.BodyEncoding = encode;

		mail.Subject = "【微笑四方】恭喜您成功通過了蟲洞連結！";
		mail.Body = "<p>您好，</p>" + 
			"<p>    謝謝您使用微笑四方。</p>" + 
			"<p>    歡迎到我們的粉絲專頁觀看您的微笑記憶，</br>" +
			"         https://www.facebook.com/QuarticSmile/ </p>"+ 
			"<p>    以下是與您進行微笑連結的夥伴之聯絡方式，</br>" + 
			"         " + otherEmail + "</p>";

		mail.Attachments.Add (GetAttachment (img1, "image1.png", encode));
		mail.Attachments.Add (GetAttachment (img2, "image2.png", encode));


		try
		{
			smtpServer.Send (mail);
		}
		catch (SmtpFailedRecipientsException exs)
		{
			Debug.Log(exs.ToString());
		}
		catch (SmtpFailedRecipientException e)
		{
			Debug.Log(e.FailedRecipient.ToString());
		}
		finally
		{
//			SMTP.Dispose();
		}


		init ();
	}

	private bool isValid(String email) 
	{
		return Regex.IsMatch (email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
	}

	private Attachment GetAttachment(byte[] image, string name, System.Text.Encoding encode)
	{
		// 設定圖片路徑
		Attachment attachment = new Attachment (new System.IO.MemoryStream (image), name);
		attachment.Name = name;
		attachment.NameEncoding = encode;
		attachment.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;

		// 設定附件為內嵌
		attachment.ContentDisposition.Inline = true;
		attachment.ContentDisposition.DispositionType = "inline";

		return attachment;
	}
}

