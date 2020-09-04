Shader "Hidden/SnapToColorShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color1 ("Color1", Color) = (0, 0, 0, 1)
        _Color2 ("Color2", Color) = (0.25, 0.25, 0.25, 1)
        _Color3 ("Color3", Color) = (0.5, 0.5, 0.5, 1)
        _Color4 ("Color4", Color) = (0.75, 0.75, 0.75, 1)
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
            fixed4 _Color1;
            fixed4 _Color2;
            fixed4 _Color3;
            fixed4 _Color4;
            
            #define PALETTE_WIDTH 4.0

            int luminosity_to_index(fixed x)
            {
                return floor(x * PALETTE_WIDTH);
            }
            
            fixed4 frag (v2f_img i) : SV_Target
            {
                fixed4 color = tex2D(_MainTex, i.uv);
                fixed grayscale = dot(color.rgb, fixed3(0.3, 0.59, 0.11)) * color.a;

                const fixed4 colors[4] = {
                    _Color1,
                    _Color2,
                    _Color3,
                    _Color4,
                };
                return colors[luminosity_to_index(grayscale)];
                // return snap_to_palette(grayscale);
                // return fixed4(grayscale, grayscale, grayscale, 1) * _Color;
            }
            ENDCG
        }
    }
}
