Shader "Hidden/SnapToPaletteShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Palette ("Palette", 2D) = "black" {}
    }
    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag

            #include "UnityCG.cginc"

            sampler2D _MainTex;
            sampler2D _Palette;
            #define PALETTE_WIDTH  4.0
            // const float PALETTE_WIDTH = 4.0;

            float4 snap_to_palette(float x)
            {
                // x = clamp(x, 0.0, 1.0);
                x = floor(x * PALETTE_WIDTH) / PALETTE_WIDTH;
                return tex2D(_Palette, float2(x, 0.0));
            }

            float4 frag (v2f_img i) : SV_Target
            {
                float4 color = tex2D(_MainTex, i.uv);
                float grayscale = dot(color.rgb, float3(0.3, 0.59, 0.11)) * color.a;
                return snap_to_palette(grayscale);
                // return grayscale;
            }
            ENDCG
        }
    }
}
