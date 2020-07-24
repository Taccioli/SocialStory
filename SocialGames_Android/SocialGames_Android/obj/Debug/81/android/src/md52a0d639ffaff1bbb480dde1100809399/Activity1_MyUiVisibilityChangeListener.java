package md52a0d639ffaff1bbb480dde1100809399;


public class Activity1_MyUiVisibilityChangeListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.view.View.OnSystemUiVisibilityChangeListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onSystemUiVisibilityChange:(I)V:GetOnSystemUiVisibilityChange_IHandler:Android.Views.View/IOnSystemUiVisibilityChangeListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("SocialGames_Android.Activity1+MyUiVisibilityChangeListener, SocialGames_Android", Activity1_MyUiVisibilityChangeListener.class, __md_methods);
	}


	public Activity1_MyUiVisibilityChangeListener ()
	{
		super ();
		if (getClass () == Activity1_MyUiVisibilityChangeListener.class)
			mono.android.TypeManager.Activate ("SocialGames_Android.Activity1+MyUiVisibilityChangeListener, SocialGames_Android", "", this, new java.lang.Object[] {  });
	}

	public Activity1_MyUiVisibilityChangeListener (android.view.View p0)
	{
		super ();
		if (getClass () == Activity1_MyUiVisibilityChangeListener.class)
			mono.android.TypeManager.Activate ("SocialGames_Android.Activity1+MyUiVisibilityChangeListener, SocialGames_Android", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public void onSystemUiVisibilityChange (int p0)
	{
		n_onSystemUiVisibilityChange (p0);
	}

	private native void n_onSystemUiVisibilityChange (int p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
