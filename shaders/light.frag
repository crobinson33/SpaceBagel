uniform sampler2D diffuseTexture;
uniform sampler2D lightMap;
uniform vec4 ambientColor;
void main()
{
    vec3 diffusePixel = texture2D(diffuseTexture, gl_TexCoord[0].xy);
	vec3 lightMapPixel = texture2D(lightMap, gl_TexCoord[0].xy);
	vec3 multiplyAmbient = diffusePixel.rgb * ambientColor.rgb;
	vec3 opacityCalc = vec3(
		(diffusePixel.r * (1.0 - ambientColor.a)) + (multiplyAmbient.r * ambientColor.a),
		(diffusePixel.g * (1.0 - ambientColor.a)) + (multiplyAmbient.g * ambientColor.a),
		(diffusePixel.b * (1.0 - ambientColor.a)) + (multiplyAmbient.b * ambientColor.a)
		);

	vec3 lightCalc = vec3((lightMapPixel.rgb * 0.1) + (opacityCalc * 0.9));
    gl_FragColor = vec4(lightCalc, 1);
}