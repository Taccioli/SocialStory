#if OPENGL
	#define SV_POSITION POSITION
	#define VS_SHADERMODEL vs_3_0
	#define PS_SHADERMODEL ps_3_0
#else
	#define VS_SHADERMODEL vs_4_0_level_9_1
	#define PS_SHADERMODEL ps_4_0_level_9_1
#endif

sampler TextureSampler : register(s0);
sampler2D inputSampler : register(S0);

float3 AdjustSaturation(float3 color, float saturation)
{
	float grey = dot(color, float3(0.3, 0.59, 0.11));
	return lerp(grey, color, saturation);
}

float4 main(float4 position : SV_Position, float4 color0 : COLOR0, float2 uv : TEXCOORD0) : COLOR
{
	float GloomIntensity = 1;
	float BaseIntensity = 0.6;
	float GloomSaturation = 0.1;
	float BaseSaturation = 1;

	float GloomThreshold = 0.25;

	float4 color = tex2D(inputSampler, uv);
	float3 base = 1 - color.rgb / color.a;
	float3 gloom = saturate((base - GloomThreshold) / (1 - GloomThreshold));


	// Adjust color saturation and intensity.
	gloom = AdjustSaturation(gloom, GloomSaturation) * GloomIntensity;
	base = AdjustSaturation(base, BaseSaturation) * BaseIntensity;

	// Darken down the base image in areas where there is a lot of bloom,
	// to prevent things looking excessively burned-out.
	base *= (1 - saturate(gloom));

	// Combine the two images.
	return float4((1 - (base + gloom)) * color.a, color.a);
}



technique Desaturate
{
	pass Pass1
	{
		PixelShader = compile PS_SHADERMODEL main();
	}
}