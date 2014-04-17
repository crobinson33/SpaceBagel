uniform vec4 thisLightColor;
uniform float thisLightIntensity;
void main()
{

	vec3 intensityCalc = thisLightColor.rgb * thisLightIntensity;

    gl_FragColor = vec4(intensityCalc,1);
}