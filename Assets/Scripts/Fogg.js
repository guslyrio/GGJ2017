#pragma strict
var cFogColor : Color = Color(0,0.4,0.7,1);
var nFogDensity : float = 0.04;

private var defaultFog : boolean;
private var defaultFogColor : Color;
private var defaultFogDensity : float;

function Start () {
defaultFog = RenderSettings.fog;
defaultFogColor = RenderSettings.fogColor;
defaultFogDensity = RenderSettings.fogDensity;

 RenderSettings.fog = true; 
   RenderSettings.fogColor = cFogColor;
   RenderSettings.fogDensity = nFogDensity;
 
 
}

function Update () {

}