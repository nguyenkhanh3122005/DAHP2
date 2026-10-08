Add-Type -AssemblyName System.Drawing

function Create-Image {
    param(
        [string]$Path,
        [int]$Width,
        [int]$Height,
        [System.Drawing.Color]$BgColor1,
        [System.Drawing.Color]$BgColor2,
        [string]$Title,
        [string]$Subtitle,
        [string]$Badge = "YAMAHA"
    )

    $bmp = New-Object System.Drawing.Bitmap($Width, $Height)
    $g = [System.Drawing.Graphics]::FromImage($bmp)
    $g.SmoothingMode = [System.Drawing.Drawing2D.SmoothingMode]::AntiAlias
    $g.TextRenderingHint = [System.Drawing.Text.TextRenderingHint]::AntiAliasGridFit

    # Linear gradient background
    $rect = New-Object System.Drawing.Rectangle(0, 0, $Width, $Height)
    $brush = New-Object System.Drawing.Drawing2D.LinearGradientBrush($rect, $BgColor1, $BgColor2, 45.0)
    $g.FillRectangle($brush, $rect)

    # Accent decorative curves / shapes
    $accentPen = New-Object System.Drawing.Pen([System.Drawing.Color]::FromArgb(40, 255, 255, 255), 3)
    $g.DrawEllipse($accentPen, [int]($Width * 0.6), -50, [int]($Width * 0.6), [int]($Height * 1.5))
    $g.DrawEllipse($accentPen, [int]($Width * 0.7), -30, [int]($Width * 0.5), [int]($Height * 1.3))

    # Badge box
    if ($Badge) {
        $badgeFont = New-Object System.Drawing.Font("Arial", 10, [System.Drawing.FontStyle]::Bold)
        $badgeBrush = New-Object System.Drawing.SolidBrush([System.Drawing.Color]::FromArgb(220, 204, 0, 0))
        $badgeTextBrush = New-Object System.Drawing.SolidBrush([System.Drawing.Color]::White)
        $badgeRect = New-Object System.Drawing.Rectangle(25, 25, 130, 26)
        $g.FillRectangle($badgeBrush, $badgeRect)
        $sf = New-Object System.Drawing.StringFormat
        $sf.Alignment = [System.Drawing.StringAlignment]::Center
        $sf.LineAlignment = [System.Drawing.StringAlignment]::Center
        $g.DrawString($Badge, $badgeFont, $badgeTextBrush, [System.Drawing.RectangleF]::new(25, 25, 130, 26), $sf)
    }

    # Title
    $titleFont = New-Object System.Drawing.Font("Arial", [int]([Math]::Max(14, $Height * 0.08)), [System.Drawing.FontStyle]::Bold)
    $titleBrush = New-Object System.Drawing.SolidBrush([System.Drawing.Color]::White)
    $titleRect = New-Object System.Drawing.RectangleF(25, ($Height * 0.35), ($Width - 50), ($Height * 0.35))
    $g.DrawString($Title, $titleFont, $titleBrush, $titleRect)

    # Subtitle
    if ($Subtitle) {
        $subFont = New-Object System.Drawing.Font("Arial", [int]([Math]::Max(10, $Height * 0.05)), [System.Drawing.FontStyle]::Regular)
        $subBrush = New-Object System.Drawing.SolidBrush([System.Drawing.Color]::FromArgb(230, 240, 240, 240))
        $subRect = New-Object System.Drawing.RectangleF(25, ($Height * 0.7), ($Width - 50), ($Height * 0.25))
        $g.DrawString($Subtitle, $subFont, $subBrush, $subRect)
    }

    # Ensure parent dir
    $dir = [System.IO.Path]::GetDirectoryName($Path)
    if (-not (Test-Path $dir)) { [System.IO.Directory]::CreateDirectory($dir) | Out-Null }

    $format = [System.Drawing.Imaging.ImageFormat]::Png
    if ($Path.EndsWith(".jpg", [System.StringComparison]::OrdinalIgnoreCase)) {
        $format = [System.Drawing.Imaging.ImageFormat]::Jpeg
    }
    $bmp.Save($Path, $format)

    $g.Dispose()
    $bmp.Dispose()
}

$base = "$pwd\wwwroot\images"

# 1. Product Images
Create-Image "$base\products\exciter-155.png" 400 300 ([System.Drawing.Color]::FromArgb(11,34,101)) ([System.Drawing.Color]::FromArgb(20,70,180)) "EXCITER 155 VVA" "155cc VVA - ABS | 52.000.000 d" "SPORT UNDERBONE"
Create-Image "$base\products\grande-hybrid.png" 400 300 ([System.Drawing.Color]::FromArgb(180,30,60)) ([System.Drawing.Color]::FromArgb(220,80,110)) "GRANDE HYBRID" "Blue Core Hybrid 125cc | 49.500.000 d" "PREMIUM SCOOTER"
Create-Image "$base\products\nvx-155.png" 400 300 ([System.Drawing.Color]::FromArgb(30,40,60)) ([System.Drawing.Color]::FromArgb(70,85,115)) "NVX 155 VVA" "Blue Core 155cc - ABS | 55.000.000 d" "MAXI SCOOTER"
Create-Image "$base\products\sirius-fi.png" 400 300 ([System.Drawing.Color]::FromArgb(40,40,45)) ([System.Drawing.Color]::FromArgb(90,90,95)) "SIRIUS FI" "115cc FI Tiet kiem xang | 21.500.000 d" "COMMUTER BIKE"
Create-Image "$base\products\janus-125.png" 400 300 ([System.Drawing.Color]::FromArgb(190,50,70)) ([System.Drawing.Color]::FromArgb(230,110,130)) "JANUS 125" "Gen Z Style - Smartkey | 29.000.000 d" "URBAN SCOOTER"
Create-Image "$base\products\jupiter-finn.png" 400 300 ([System.Drawing.Color]::FromArgb(35,50,75)) ([System.Drawing.Color]::FromArgb(60,85,120)) "JUPITER FINN" "Phanh ket hop UBS 115cc | 27.500.000 d" "FAMILY BIKE"
Create-Image "$base\products\r15-v4.png" 400 300 ([System.Drawing.Color]::FromArgb(10,30,95)) ([System.Drawing.Color]::FromArgb(25,75,190)) "YZF-R15 V4" "Quick Shifter - USD | 78.000.000 d" "R-SERIES RACING"
Create-Image "$base\products\mt-15.png" 400 300 ([System.Drawing.Color]::FromArgb(20,20,25)) ([System.Drawing.Color]::FromArgb(0,180,210)) "MT-15 NAKED" "Dark Side of Japan 155cc | 69.000.000 d" "MASTER OF TORQUE"
Create-Image "$base\products\neos-electric.png" 400 300 ([System.Drawing.Color]::FromArgb(15,100,105)) ([System.Drawing.Color]::FromArgb(40,180,160)) "NEO'S ELECTRIC" "Pin Lithium thao roi | 49.000.000 d" "SMART EV SCOOTER"

# 2. Ads Banners (Mục 2.d - Điểm Giỏi)
Create-Image "$base\ads\banner-tra-gop.png" 350 200 ([System.Drawing.Color]::FromArgb(200,20,30)) ([System.Drawing.Color]::FromArgb(120,10,20)) "MUA XE TRA GOP 0%" "Lai suat uu dai - Nhan xe ngay sau 15 phut" "YAMAHA FINANCE"
Create-Image "$base\ads\banner-tang-non.png" 350 200 ([System.Drawing.Color]::FromArgb(11,34,101)) ([System.Drawing.Color]::FromArgb(30,80,180)) "TANG NON BH CHINH HANG" "Kem Voucher bao duong 1.000.000 VNÐ" "QUA TANG TRI AN"
Create-Image "$base\ads\banner-tri-an.png" 900 200 ([System.Drawing.Color]::FromArgb(180,30,40)) ([System.Drawing.Color]::FromArgb(230,150,30)) "LE HOI TRI AN KHACH HANG 2025" "Quay so trung xe Grande Hybrid & 10 chi vang 9999 tai Yamaha Town" "UU DAI DAC BIET"
Create-Image "$base\ads\banner-doi-xe.png" 350 200 ([System.Drawing.Color]::FromArgb(30,30,35)) ([System.Drawing.Color]::FromArgb(80,20,30)) "THU CU DOI MOI EXCITER" "Tro gia truc tiep len toi 4.000.000 VND" "LEN DOI XE XIN"

# 3. Sliders
Create-Image "$base\banners\slider-1.jpg" 1200 450 ([System.Drawing.Color]::FromArgb(11,34,101)) ([System.Drawing.Color]::FromArgb(25,75,190)) "YAMAHA EXCITER 155 VVA - ABS" "Dong co 155cc van bien thien manh me - Ong vua duong pho the he moi" "NEW GENERATION 2025"
Create-Image "$base\banners\slider-2.jpg" 1200 450 ([System.Drawing.Color]::FromArgb(180,25,45)) ([System.Drawing.Color]::FromArgb(220,70,95)) "YAMAHA GRANDE BLUE CORE HYBRID" "Nu hoang tiet kiem xang so 1 Viet Nam - Tro luc dien Hybrid em ai" "ECO & SMART SCOOTER"
Create-Image "$base\banners\slider-3.jpg" 1200 450 ([System.Drawing.Color]::FromArgb(25,25,30)) ([System.Drawing.Color]::FromArgb(60,60,70)) "DANG KY LAI THU TRAI NGHIEM MIEN PHI" "Trai nghiem thuc te tat ca cac dong xe moi nhat tai Yamaha Town Viet-Hung" "TEST RIDE NOW"

# 4. News
Create-Image "$base\news\news-exciter.jpg" 500 300 ([System.Drawing.Color]::FromArgb(15,35,90)) ([System.Drawing.Color]::FromArgb(40,90,190)) "Exciter 155 VVA ABS Ra Mat" "Phien ban dac biet nang cap he thong phanh ABS an toan" "TIN SAN PHAM"
Create-Image "$base\news\news-grande.jpg" 500 300 ([System.Drawing.Color]::FromArgb(170,30,55)) ([System.Drawing.Color]::FromArgb(210,80,105)) "Uu Dai Truoc Ba Grande" "Ho tro 100% le phi truoc ba hoac qua tang 2 trieu dong" "KHUYEN MAI HOT"
Create-Image "$base\news\news-service.jpg" 500 300 ([System.Drawing.Color]::FromArgb(30,50,80)) ([System.Drawing.Color]::FromArgb(70,110,160)) "Quy Trinh Bao Duong Chuan" "6 buoc cham soc xe may theo tieu chuan Yamaha Nhat Ban" "DICH VU 3S"

Write-Host ">>> COMPLETED GENERATING ALL ASSETS SUCCESSFULLY!"
