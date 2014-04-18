uniform float thisLightIntensity;
void main()
{
	vec4 intensityCalc = vec4((gl_Color.rgb * thisLightIntensity), gl_Color.a);

    gl_FragColor = vec4(intensityCalc);
}