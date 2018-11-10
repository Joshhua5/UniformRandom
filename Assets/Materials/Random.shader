Shader "Unlit/Random"
{
	Properties
	{
		_Random ("Texture", 2D) = "white" {}
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
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			half3 frag (v2f i) : SV_Target
			{
				// sample the texture
				half3 random = tex2D(_Random, i.uv);
					  random = tex2D(_Random, i.uv + random); 

				return random;
			}
			ENDCG
		}
	}
}
