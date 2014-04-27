uniform sampler2D texture;
uniform float tweenValue;
void main()
{
	vec4 pixel = texture2D(texture, gl_TexCoord[0].xy);

	vec4 red = vec4(1,0,0,0);

	vec4 calcTween = vec4(mix(red, pixel, tweenValue));

    gl_FragColor = vec4(calcTween.rgb, (pixel.a * calcTween.a));
}