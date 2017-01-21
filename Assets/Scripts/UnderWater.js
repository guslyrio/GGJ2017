#pragma strict


var cFogColor : Color = Color(0,0.4,0.7,1);
var nFogDensity : float = 0.04;

private var defaultFog : boolean;
private var defaultFogColor : Color;
private var defaultFogDensity : float;

var UnderWaterPlane : GameObject = null;

function Start () {

defaultFog = RenderSettings.fog;
defaultFogColor = RenderSettings.fogColor;
defaultFogDensity = RenderSettings.fogDensity;

}

function OnTriggerEnter (other : Collider) 
{
 if 
 (other.name =="First Person Controller")
  
  {
   RenderSettings.fog = true; 
   RenderSettings.fogColor = cFogColor;
   RenderSettings.fogDensity = nFogDensity;
   if(UnderWaterPlane != null)
   UnderWaterPlane.active = true;
  } 


}

function OnTriggerExit (other : Collider)

{
 if(other.name == "First Person Controller")
  {
  RenderSettings.fog = defaultFog;
  RenderSettings.fogColor = defaultFogColor;
  RenderSettings.fogDensity = defaultFogDensity;
   
    if(UnderWaterPlane != null)
      UnderWaterPlane.active = false;
      }
}