uniform sampler2D texture;
uniform float tweenValue;
void main()
{
	vec4 pixel = texture2D(texture, gl_TexCoord[0].xy);

	vec3 white = vec3(1,1,1);

	vec3 calcTween = vec3(mix(white, pixel.rgb, tweenValue));

    gl_FragColor = vec4(calcTween,pixel.a);
}