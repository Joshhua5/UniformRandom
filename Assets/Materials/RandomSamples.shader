Shader "Unlit/RandomSamples"
{
	Properties
	{
		_Random ("Texture", 2D) = "white" {} 

		_Sample("View Sample", Int) = 8
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0; 
				float4 vertex : SV_POSITION;
			};

			sampler2D _Random;
			float4 _MainTex_ST;
			uniform half4 _RandomArray[8];
			uniform int _Sample;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			half3 frag (v2f i) : SV_Target
			{
				// Sample the texture for a seed
				// We can either have a random texture large enough, or sample it twice
				// with the first result as an offset to create per pixel random value
				half3 random = tex2D(_Random, i.uv);  
					  random = tex2D(_Random, i.uv + random);

				
				const int viewSample = clamp(0, 8, _Sample);
				for (int index = 0; index < viewSample; ++index) {
					random = cross(_RandomArray[index], random);

					// Do work that uses this random vector

				}

				return random;
			}
			ENDCG
		}
	}
}
