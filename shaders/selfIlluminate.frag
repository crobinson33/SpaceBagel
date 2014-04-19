uniform sampler2D texture;
void main()
{
	vec4 pixel = texture2D(texture, gl_TexCoord[0].xy);

	vec3 white = vec3(1,1,1);

    gl_FragColor = vec4(white,pixel.a);
}