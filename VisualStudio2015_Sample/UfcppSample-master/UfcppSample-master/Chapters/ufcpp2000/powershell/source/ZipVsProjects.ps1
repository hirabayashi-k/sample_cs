param([string]$path)

. .\ZipLib.ps1

# �e���|�����t�@�C������
$name = [IO.Path]::GetFileName($path)
$fullname = [IO.Path]::GetFileName($path)
$tempPath = [IO.Path]::GetTempPath()

# �R�s�[���s�v�t�@�C���̍폜
cp $fullname $tempPath -Recurse -Force

Push-Location $tempPath

rm ($name + '\*.suo') -Force
rm ($name + '\*\obj') -Recurse -Force
rm ($name + '\*\bin') -Recurse -Force

# ZIP �쐬
$tempZip = [IO.Path]::GetTempFileName()
mv $tempZip ($tempZip + '.zip')
$tempZip = ($tempZip + '.zip')

New-Zip $tempZip

ls $name | Add-Zip $tempZip

# �ꎞ�t�@�C������
rm $name -Recurse -Force

# ����� ZIP �̃R�s�[
Pop-Location
mv $tempZip ('.\' + $name + '.zip') -Force
