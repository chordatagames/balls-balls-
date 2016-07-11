Shader "Cg shading in world space" {
	Properties{
		_MainTex("Texture Image", 2D) = "white" {}
		_Point("a point in world space", Vector) = (0., 0., 0., 1.0)
		_DistanceNear("threshold distance", Float) = 5.0
		_ColorNear("color near to point", Color) = (0.0, 1.0, 0.0, 1.0)
		_ColorFar("color far from point", Color) = (0.3, 0.3, 0.3, 1.0)
	}

		SubShader{
		Pass{
		CGPROGRAM

#pragma vertex vert  
#pragma fragment frag 

#include "UnityCG.cginc" 
		// defines _Object2World and _World2Object

		// uniforms corresponding to properties
		uniform float4 _Point;
		uniform float _DistanceNear;
		uniform float4 _ColorNear;
		uniform float4 _ColorFar;

	struct vertexInput {
		float4 vertex : POSITION;
	};
	struct vertexOutput {
		float4 pos : SV_POSITION;
		float4 position_in_world_space : TEXCOORD0;
	};

	vertexOutput vert(vertexInput input)
	{
		vertexOutput output;

		output.pos = mul(UNITY_MATRIX_MVP, input.vertex);
		output.position_in_world_space =
			mul(_Object2World, input.vertex);
		return output;
	}

	float4 frag(vertexOutput input) : COLOR
	{
		float dist = distance(input.position_in_world_space,_Point);
	// computes the distance between the fragment position 
	// and the position _Point.
	return lerp(_ColorNear, _ColorFar, dist / _DistanceNear);
	
	}

		ENDCG
	}
	}
}